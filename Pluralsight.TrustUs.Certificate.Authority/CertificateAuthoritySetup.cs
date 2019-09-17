﻿using System.Collections.Generic;
using System.IO;
using cryptlib;

namespace Pluralsight.TrustUs
{
    public class CertificateAuthoritySetup
    {
        /// <summary>
        ///     Installs the specified root certificate authority.
        /// </summary>
        /// <param name="rootCertificateAuthority">The root certificate authority.</param>
        /// <param name="intermediateCertificateAuthorities">The intermediate certificate authorities.</param>
        public void Install(CertificateAuthorityConfiguration rootCertificateAuthority,
            List<CertificateConfiguration> intermediateCertificateAuthorities)
        {
            GenerateRootCaCertificate(rootCertificateAuthority);
            InitializeCertificateStore(rootCertificateAuthority);
            foreach (var configuration in intermediateCertificateAuthorities)
                RequestIntermediateCertificate(configuration);
        }

        /// <summary>
        ///     Starts the ocsp server.
        /// </summary>
        public void StartOcspServer()
        {
            var ocspSession = crypt.CreateSession(crypt.UNUSED, crypt.SESSION_OCSP_SERVER);
        }

        /// <summary>
        ///     Starts the CMP server.
        /// </summary>
        public void StartCmpServer()
        {
        }
        
        /// <summary>
        ///     Generates the root ca certificate.
        /// </summary>
        /// <param name="rootCertificateAuthority">The root certificate authority.</param>
        private void GenerateRootCaCertificate(CertificateAuthorityConfiguration rootCertificateAuthority)
        {
            /* Create an RSA public/private key context, set a label for it, and generate a key into it */
            var caKeyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);

            crypt.SetAttributeString(caKeyPair, crypt.CTXINFO_LABEL, rootCertificateAuthority.KeyLabel);
            crypt.SetAttribute(caKeyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(caKeyPair);

            var caKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE,
                rootCertificateAuthority.KeystoreFileName,
                crypt.KEYOPT_CREATE);
            crypt.AddPrivateKey(caKeyStore, caKeyPair, rootCertificateAuthority.PrivateKeyPassword);

            var certificate = crypt.CreateCert(crypt.UNUSED, crypt.CERTTYPE_CERTIFICATE);

            crypt.SetAttribute(certificate, crypt.CERTINFO_SUBJECTPUBLICKEYINFO, caKeyPair);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_COUNTRYNAME,
                rootCertificateAuthority.DistinguishedName.Country);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_STATEORPROVINCENAME,
                rootCertificateAuthority.DistinguishedName.State);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_LOCALITYNAME,
                rootCertificateAuthority.DistinguishedName.Locality);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_ORGANIZATIONNAME,
                rootCertificateAuthority.DistinguishedName.Organization);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_ORGANIZATIONALUNITNAME,
                rootCertificateAuthority.DistinguishedName.OrganizationalUnit);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_COMMONNAME,
                rootCertificateAuthority.DistinguishedName.CommonName);

            crypt.SetAttribute(certificate, crypt.CERTINFO_SELFSIGNED, 1);
            crypt.SetAttribute(certificate, crypt.CERTINFO_CA, 1);

            crypt.SetAttribute(certificate, crypt.ATTRIBUTE_CURRENT, crypt.CERTINFO_AUTHORITYINFO_CERTSTORE);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_UNIFORMRESOURCEIDENTIFIER,
                rootCertificateAuthority.CertStoreUrl);

            crypt.SetAttribute(certificate, crypt.ATTRIBUTE_CURRENT, crypt.CERTINFO_AUTHORITYINFO_OCSP);
            crypt.SetAttributeString(certificate, crypt.CERTINFO_UNIFORMRESOURCEIDENTIFIER,
                rootCertificateAuthority.OcspUrl);

            crypt.SignCert(certificate, caKeyPair);

            crypt.AddPublicKey(caKeyStore, certificate);

            var dataSize = crypt.ExportCert(null, 0, crypt.CERTFORMAT_CERTIFICATE, certificate);
            var exportedCert = new byte[dataSize];
            crypt.ExportCert(exportedCert, dataSize, crypt.CERTFORMAT_CERTIFICATE, certificate);

            File.WriteAllBytes(rootCertificateAuthority.CertificateFileName, exportedCert);

            crypt.KeysetClose(caKeyStore);
            crypt.DestroyContext(caKeyPair);
            crypt.DestroyCert(certificate);
        }

        /// <summary>
        ///     Initializes the certificate store.
        /// </summary>
        private void InitializeCertificateStore(CertificateAuthorityConfiguration rootCertificateAuthority)
        {
            if (!File.Exists(rootCertificateAuthority.CertificateStoreFilePath))
            {
                var file = File.Create(rootCertificateAuthority.CertificateStoreFilePath);
                file.Close();
            }

            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, rootCertificateAuthority.CertificateStoreOdbcName, crypt.KEYOPT_CREATE);
            crypt.KeysetClose(certStore);
        }

        /// <summary>
        /// Requests the intermediate certificate.
        /// </summary>
        /// <param name="certificateConfiguration">The certificate configuration.</param>
        private void RequestIntermediateCertificate(CertificateConfiguration certificateConfiguration)
        {
            /* Create an RSA public/private key context, set a label for it, and generate a key into it */
            var icaKeyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);

            crypt.SetAttributeString(icaKeyPair, crypt.CTXINFO_LABEL, certificateConfiguration.KeyLabel);
            crypt.SetAttribute(icaKeyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(icaKeyPair);

            var icaKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE,
                certificateConfiguration.KeystoreFileName,
                crypt.KEYOPT_CREATE);

            crypt.AddPrivateKey(icaKeyStore, icaKeyPair, certificateConfiguration.PrivateKeyPassword);

            var certRequest = crypt.CreateCert(crypt.UNUSED, crypt.CERTTYPE_CERTREQUEST);

            crypt.SetAttribute(certRequest, crypt.CERTINFO_SUBJECTPUBLICKEYINFO, icaKeyPair);
            crypt.SetAttributeString(certRequest, crypt.CERTINFO_COUNTRYNAME,
                certificateConfiguration.DistinguishedName.Country);
            crypt.SetAttributeString(certRequest, crypt.CERTINFO_ORGANIZATIONNAME,
                certificateConfiguration.DistinguishedName.Organization);
            crypt.SetAttributeString(certRequest, crypt.CERTINFO_ORGANIZATIONALUNITNAME,
                certificateConfiguration.DistinguishedName.OrganizationalUnit);
            crypt.SetAttributeString(certRequest, crypt.CERTINFO_COMMONNAME,
                certificateConfiguration.DistinguishedName.CommonName);

            crypt.SignCert(certRequest, icaKeyPair);

            var dataSize = crypt.ExportCert(null, 0, crypt.CERTFORMAT_CERTIFICATE, certRequest);
            var exportedCert = new byte[dataSize];
            crypt.ExportCert(exportedCert, dataSize * 2, crypt.CERTFORMAT_CERTIFICATE, certRequest);

            File.WriteAllBytes(certificateConfiguration.CertificateFileName, exportedCert);

            crypt.DestroyCert(certRequest);

            crypt.KeysetClose(icaKeyStore);
            crypt.DestroyContext(icaKeyPair);
        }
    }
}