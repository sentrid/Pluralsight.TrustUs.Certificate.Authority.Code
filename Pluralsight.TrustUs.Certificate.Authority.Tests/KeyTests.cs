using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluralsight.TrustUs.DataStructures;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs.Tests
{
    [TestClass]
    public class KeyTests
    {
        [TestInitialize]
        public void InitializeTests()
        {
            if (Directory.Exists(@"C:\Pluralsight\Tests"))
            {
                Directory.Delete(@"C:\Pluralsight\Tests", true);
            }

            Directory.CreateDirectory(@"C:\Pluralsight\Tests");

            crypt.Init();
        }

        [TestCleanup]
        public void TerminateTests()
        {
            crypt.End();
        }

        [TestMethod]
        public void TestGenerateKey()
        {
            var keyConfiguration = new KeyConfiguration
            {
                KeyLabel = "DuckAirlinesTest",
                PrivateKeyPassword = "P@ssw0rd",
                CertificateRequestFileName = @"C:\Pluralsight\Tests\DuckAirCert.csr",
                KeystoreFileName = @"C:\Pluralsight\Tests\DuckAirKey.key",
                DistinguishedName = new DistinguishedName
                {
                    CommonName = "Test Certificate Name",
                    Country = "US",
                    Locality = "Cleveland",
                    Organization = "Duck Airlines",
                    OrganizationalUnit = "Security",
                    State = "OH"
                }
            };

            Key.GenerateKeyPair(keyConfiguration);
        }
    }
}