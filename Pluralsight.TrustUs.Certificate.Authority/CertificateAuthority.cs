﻿using System.ComponentModel;
using System.IO;
using cryptlib;

namespace Pluralsight.TrustUs
{
    public class CertificateAuthority
    {
        public void Install()
        {
            GenerateKeyPair();
            InitializeCertificateStore();
        }

        
        public void StartOcspServer()
        {
            var ocspSession = crypt.CreateSession(crypt.UNUSED, crypt.SESSION_OCSP_SERVER);
        }

        private void GenerateKeyPair()
        {

            /* Create an RSA public/private key context, set a label for it, and generate a key into it */
            var caKeyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);
            
            crypt.SetAttributeString(caKeyPair, crypt.CTXINFO_LABEL, "TrustUsCaKeyPair");
            crypt.SetAttribute(caKeyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(caKeyPair);

            var caKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, @"C:\Pluralsight\Keys\ca.keys", crypt.KEYOPT_CREATE);
            crypt.AddPrivateKey(caKeyStore, caKeyPair, @"P@ssw0rd");

            GenerateCaCertificate(caKeyPair, caKeyStore);

            crypt.KeysetClose(caKeyStore);
            crypt.DestroyContext(caKeyPair);
        }

        private void GenerateCaCertificate(int caKeyPair, int keyStore)
        {
            var certificate = crypt.CreateCert(crypt.UNUSED, crypt.CERTTYPE_CERTIFICATE);

            crypt.SetAttribute(certificate, crypt.CERTINFO_SUBJECTPUBLICKEYINFO, caKeyPair);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_COUNTRYNAME, "US");
            crypt.SetAttributeString(certificate, crypt.CERTINFO_ORGANIZATIONNAME, "Trust Us");
            crypt.SetAttributeString(certificate, crypt.CERTINFO_ORGANIZATIONALUNITNAME, "Security");
            crypt.SetAttributeString(certificate, crypt.CERTINFO_COMMONNAME, "Root Certificate Authority");

            crypt.SetAttribute(certificate, crypt.CERTINFO_SELFSIGNED, 1);
            crypt.SetAttribute(certificate, crypt.CERTINFO_CA, 1);

            crypt.SetAttribute(certificate, crypt.ATTRIBUTE_CURRENT, crypt.CERTINFO_AUTHORITYINFO_CERTSTORE);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_UNIFORMRESOURCEIDENTIFIER, "http://www.domain.com");

            crypt.SetAttribute(certificate, crypt.ATTRIBUTE_CURRENT, crypt.CERTINFO_AUTHORITYINFO_OCSP);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_UNIFORMRESOURCEIDENTIFIER, "http://www.domain.com");

            crypt.SignCert(certificate, caKeyPair);

            crypt.AddPublicKey(keyStore, certificate);

            var dataSize = crypt.ExportCert(null, 0, crypt.CERTFORMAT_TEXT_CERTIFICATE, certificate);
            byte[] exportedCert = new byte[dataSize];
            crypt.ExportCert(exportedCert, dataSize, crypt.CERTFORMAT_TEXT_CERTIFICATE, certificate);

            File.WriteAllBytes(@"C:\Pluralsight\Keys\ca.cer", exportedCert);

            crypt.DestroyCert(certificate);
        }

        private void InitializeCertificateStore()
        {
            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, "TrustUs", crypt.KEYOPT_CREATE);
            crypt.KeysetClose(certStore);
        }

    }
}