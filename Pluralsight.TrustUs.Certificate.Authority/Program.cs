using System;
using System.Collections.Generic;
using cryptlib;

namespace Pluralsight.TrustUs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            crypt.Init();
            var trustUsCertificateAuthority = new CertificateAuthority();
            var rootCaConfiguration = new CertificateConfiguration
            {
                CertificateFileName = @"C:\Pluralsight\Keys\ca.cer",
                KeystoreFileName = @"C:\Pluralsight\Keys\ca.key",
                DistinguishedName = new DistinguishedName
                {
                    Country = "US",
                    State = "OH",
                    Locality = "Cleveland",
                    Organization = "Trust Us",
                    OrganizationalUnit = "Certificates",
                    CommonName = "Root Certificate"
                },
                KeyLabel = "Root",
                PrivateKeyPassword = "P@ssw0rd"
            };

            var intermediateCertificateAuthorities = new List<CertificateConfiguration>();
            intermediateCertificateAuthorities.Add(new CertificateConfiguration
            {
                CertificateFileName = @"C:\Pluralsight\Keys\clevelandIca.cer",
                KeystoreFileName = @"C:\Pluralsight\Keys\clevelandIca.key",
                DistinguishedName = new DistinguishedName
                {
                    Country = "US",
                    State = "OH",
                    Locality = "Cleveland",
                    Organization = "Trust Us",
                    OrganizationalUnit = "Certificates",
                    CommonName = "Cleveland Certificate"
                },
                KeyLabel = "Cleveland",
                PrivateKeyPassword = "P@ssw0rd",
                SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
                SigningKeyLabel = "Root",
                SigningKeyPassword = "P@ssw0rd"
            });

            var done = false;
            do
            {
                switch (DisplayMenu())
                {
                    case 1:
                        trustUsCertificateAuthority.Install(rootCaConfiguration, intermediateCertificateAuthorities);
                        break;
                    case 5:
                        done = true;
                        break;
                }
            } while (!done);

            //var keysetOpen = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, @"C:\Pluralsight\Keys\ica.keys", crypt.KEYOPT_READONLY);
            //var cert = crypt.GetPublicKey(keysetOpen, crypt.KEYID_NAME, "TrustUsIcaKeyPair");
            //var size = crypt.ExportCert(null, 0, crypt.CERTFORMAT_CERTCHAIN, cert);
            //byte[] certificate = new byte[size];
            //crypt.ExportCert(certificate, size, crypt.CERTFORMAT_CERTCHAIN, cert);
            //System.IO.File.WriteAllBytes(@"C:\Pluralsight\Keys\ica.cer", certificate);
            //crypt.KeysetClose(keysetOpen);

            crypt.End();
        }

        public static int DisplayMenu()
        {
            Console.WriteLine("TrustUs Certificate Authority");
            Console.WriteLine();
            Console.WriteLine("1. Install Certificate Authority");
            Console.WriteLine("2. Create Key Pair");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}