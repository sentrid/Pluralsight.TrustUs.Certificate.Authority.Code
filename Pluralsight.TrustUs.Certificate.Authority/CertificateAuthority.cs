using System.Collections.Generic;
using System.IO;
using Pluralsight.TrustUs.DataStructures;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs
{
    /// <summary>
    ///     Class CertificateAuthority.
    /// </summary>
    public class CertificateAuthority
    {
        public void SubmitCertificateRequest(string certificateRequestFileName)
        {
            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, @"TrustUsTest",
                crypt.KEYOPT_NONE);

            var requestCertificate = File.ReadAllText(certificateRequestFileName);
            var certRequest = crypt.ImportCert(requestCertificate, crypt.UNUSED);
            crypt.CAAddItem(certStore, certRequest);

            crypt.KeysetClose(certStore);
        }

        public void IssueCertificate(CertificateConfiguration certificateConfiguration)
        {
            var caKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, certificateConfiguration.SigningKeyFileName,
                crypt.KEYOPT_READONLY);
            var caKey = crypt.GetPrivateKey(caKeyStore, crypt.KEYID_NAME, certificateConfiguration.SigningKeyLabel, certificateConfiguration.SigningKeyPassword);

            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, @"TrustUsTest",
                crypt.KEYOPT_NONE);

            var certRequest = crypt.CAGetItem(certStore, crypt.CERTTYPE_REQUEST_CERT, crypt.KEYID_NAME,
                certificateConfiguration.DistinguishedName.CommonName);

            crypt.CACertManagement(crypt.CERTACTION_ISSUE_CERT, certStore, caKey, certRequest);

            var caGetItem = crypt.CAGetItem(certStore, crypt.CERTTYPE_CERTCHAIN, crypt.KEYID_NAME,
                certificateConfiguration.DistinguishedName.CommonName);

            var certificate = new Certificate();
            File.WriteAllText(certificateConfiguration.CertificateFileName, certificate.ExportCertificateAsText(caGetItem));

            crypt.KeysetClose(caKeyStore);
            crypt.KeysetClose(certStore);
        }

        public void RevokeCertificate(string revokedFileName, string caKeyFileName)
        {
            var certificate = new Certificate();
            var importCertificate = certificate.ImportCertificate(File.ReadAllText(revokedFileName));
            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, @"TrustUsTest",
                crypt.KEYOPT_NONE);
            var caKey = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, caKeyFileName, crypt.KEYOPT_READONLY);
            crypt.CACertManagement(crypt.CERTACTION_REVOKE_CERT, certStore, caKey, importCertificate);

            crypt.KeysetClose(certStore);
            crypt.KeysetClose(caKey);
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
    }
}