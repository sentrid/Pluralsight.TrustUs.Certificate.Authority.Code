using System.Collections.Generic;
using System.IO;
using cryptlib;

namespace Pluralsight.TrustUs
{
    /// <summary>
    ///     Class CertificateAuthority.
    /// </summary>
    public class CertificateAuthority
    {
        public void SubmitCertificateRequest()
        {
            var certStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC_STORE, @"TrustUs",
                crypt.KEYOPT_NONE);
            var readAllBytes = File.ReadAllBytes(@"C:\Pluralsight\cleveland.cer");
            var certRequest = crypt.ImportCert(readAllBytes, crypt.UNUSED);
            crypt.CAAddItem(certStore, certRequest);

            var caKeyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, @"C:\Pluralsight\ca.key",
                crypt.KEYOPT_READONLY);
            var caKey = crypt.GetPrivateKey(caKeyStore, crypt.KEYID_NAME, "", "P@ssw0rd");
            crypt.CACertManagement(crypt.CERTACTION_ISSUE_CERT, certStore, caKey, certRequest);
            var caGetItem = crypt.CAGetItem(certStore, crypt.CERTTYPE_CERTCHAIN, crypt.KEYID_NAME, "");
        }
    }
}