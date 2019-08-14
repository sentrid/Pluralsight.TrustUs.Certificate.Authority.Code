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

            crypt.End();
        }
    }
}
