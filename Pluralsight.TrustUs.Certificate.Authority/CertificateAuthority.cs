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
            //CreateIntermediateCert();
        }


        public void StartOcspServer()
        {
            var ocspSession = crypt.CreateSession(crypt.UNUSED, crypt.SESSION_OCSP_SERVER);
        }

        public void StartCmpServer()
        {

        }

        private void GenerateKeyPair()
        {
            /* Create an RSA public/private key context, set a label for it, and generate a key into it */
            var caKeyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);

            crypt.SetAttributeString(caKeyPair, crypt.CTXINFO_LABEL, "TrustUsCaKeyPair");
            crypt.SetAttribute(caKeyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(caKeyPair);

            var caKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, @"C:\Pluralsight\Keys\ca.keys",
                crypt.KEYOPT_CREATE);
            crypt.AddPrivateKey(caKeyStore, caKeyPair, @"P@ssw0rd");

            GenerateRootCaCertificate(caKeyPair, caKeyStore);

            crypt.KeysetClose(caKeyStore);
            crypt.DestroyContext(caKeyPair);
        }

        private void GenerateRootCaCertificate(int caKeyPair, int keyStore)
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

            var dataSize = crypt.ExportCert(null, 0, crypt.CERTFORMAT_CERTIFICATE, certificate);
            var exportedCert = new byte[dataSize];
            crypt.ExportCert(exportedCert, dataSize, crypt.CERTFORMAT_CERTIFICATE, certificate);

            File.WriteAllBytes(@"C:\Pluralsight\Keys\ca.cer", exportedCert);

            crypt.DestroyCert(certificate);
        }

        private void InitializeCertificateStore()
        {
            if (!File.Exists(@"C:\Pluralsight\Keys\TrustUsStore.db"))
            {
                var file = File.Create(@"C:\Pluralsight\Keys\TrustUsStore.db");
                file.Close();
            }

            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, "TrustUs", crypt.KEYOPT_CREATE);
            crypt.KeysetClose(certStore);
        }

        private void CreateIntermediateCert(CaServerConfiguration caServerConfiguration)
        {
            /***************************************************************/
            /*                  Get the CA Certificate                     */
            /***************************************************************/
            var caKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, caServerConfiguration.SigningKeyFileName,
                crypt.KEYOPT_READONLY);
            var caPrivateKey = crypt.GetPrivateKey(caKeyStore, crypt.KEYID_NAME, caServerConfiguration.SigningKeyLabel,
                caServerConfiguration.SigningKeyPassword);

            /* Create an RSA public/private key context, set a label for it, and generate a key into it */
            var icaKeyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);

            crypt.SetAttributeString(icaKeyPair, crypt.CTXINFO_LABEL, caServerConfiguration.KeyLabel);
            crypt.SetAttribute(icaKeyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(icaKeyPair);

            var icaKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, caServerConfiguration.KeystoreFileName,
                crypt.KEYOPT_CREATE);
            crypt.AddPrivateKey(icaKeyStore, icaKeyPair, caServerConfiguration.PrivateKeyPassword);

            var certChain = crypt.CreateCert(crypt.UNUSED, crypt.CERTTYPE_CERTCHAIN);

            crypt.SetAttribute(certChain, crypt.CERTINFO_SUBJECTPUBLICKEYINFO, icaKeyPair);
            crypt.SetAttributeString(certChain, crypt.CERTINFO_COUNTRYNAME,
                caServerConfiguration.DistinguishedName.Country);
            crypt.SetAttributeString(certChain, crypt.CERTINFO_ORGANIZATIONNAME,
                caServerConfiguration.DistinguishedName.Organization);
            crypt.SetAttributeString(certChain, crypt.CERTINFO_ORGANIZATIONALUNITNAME,
                caServerConfiguration.DistinguishedName.OrganizationalUnit);
            crypt.SetAttributeString(certChain, crypt.CERTINFO_COMMONNAME,
                caServerConfiguration.DistinguishedName.CommonName);
            crypt.SetAttribute(certChain, crypt.CERTINFO_CA, 1);

            crypt.SignCert(certChain, caPrivateKey);
            crypt.AddPublicKey(icaKeyStore, certChain);

            var dataSize = crypt.ExportCert(null, 0, crypt.CERTFORMAT_CERTIFICATE, certChain);
            var exportedCert = new byte[dataSize];
            crypt.ExportCert(exportedCert, dataSize * 2, crypt.CERTFORMAT_CERTIFICATE, certChain);

            File.WriteAllBytes(caServerConfiguration.CertificateFileName, exportedCert);

            crypt.DestroyCert(certChain);
            crypt.KeysetClose(icaKeyStore);
            crypt.KeysetClose(caKeyStore);
            crypt.DestroyContext(caPrivateKey);
            crypt.DestroyContext(icaKeyPair);
        }
    }
}