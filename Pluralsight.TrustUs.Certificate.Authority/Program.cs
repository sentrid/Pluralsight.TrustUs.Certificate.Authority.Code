using System;
using cryptlib;

namespace Pluralsight.TrustUs
{
    class Program
    {
        static void Main(string[] args)
        {
            crypt.Init();

            var done = false;
            var ca = new CertificateAuthority();

            do
            {
                switch(DisplayMenu())
                {
                    case 1:
                        ca.Install();
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

        static public int DisplayMenu()
        {
            Console.WriteLine("TrustUs Certificate Authority");
            Console.WriteLine();
            Console.WriteLine("1. Install Certificate Authority");
            Console.WriteLine("2. List the Football teams");
            Console.WriteLine("3. Search for a Football team");
            Console.WriteLine("4. Delete a team");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
