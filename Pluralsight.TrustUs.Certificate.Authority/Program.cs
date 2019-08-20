using System.ComponentModel;
using cryptlib;

namespace Pluralsight.TrustUs
{
    class Program
    {
        static void Main(string[] args)
        {
            crypt.Init();

            var ca = new CertificateAuthority();
            ca.Install();

            //var keysetOpen = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, @"C:\Pluralsight\Keys\ica.keys", crypt.KEYOPT_READONLY);
            //var cert = crypt.GetPublicKey(keysetOpen, crypt.KEYID_NAME, "TrustUsIcaKeyPair");
            //var size = crypt.ExportCert(null, 0, crypt.CERTFORMAT_CERTCHAIN, cert);
            //byte[] certificate = new byte[size];
            //crypt.ExportCert(certificate, size, crypt.CERTFORMAT_CERTCHAIN, cert);
            //System.IO.File.WriteAllBytes(@"C:\Pluralsight\Keys\ica.cer", certificate);
            //crypt.KeysetClose(keysetOpen);

            crypt.End();
        }
    }
}
