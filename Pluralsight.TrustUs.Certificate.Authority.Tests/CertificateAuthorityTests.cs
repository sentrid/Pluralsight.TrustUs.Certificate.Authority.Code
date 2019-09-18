using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluralsight.TrustUs.DataStructures;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs.Tests
{
    [TestClass]
    public class CertificateAuthorityTests
    {
        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            //if (Directory.Exists(@"C:\Pluralsight\Test\Keys"))
            //{
            //    Directory.Delete(@"C:\Pluralsight\Test\Keys", true);
            //}

            //Directory.CreateDirectory(@"C:\Pluralsight\Test\Keys");

            crypt.Init();
        }

        [ClassCleanup]
        public static void TerminateTests()
        {
            crypt.End();
        }

        [TestMethod]
        public void TestCreateCa()
        {
            var certificateAuthoritySetup = new CertificateAuthoritySetup();

            var intermediateCertificateAuthorities = new List<CertificateConfiguration>
            {
                TestData.Berlin,
                TestData.Capetown,
                TestData.Cleveland,
                TestData.Moscow,
                TestData.Mumbai,
                TestData.Santiago,
                TestData.Sydney
            };
            certificateAuthoritySetup.Install(TestData.Root, intermediateCertificateAuthorities);
        }

        [TestMethod]
        public void TestSubmitCsr()
        {
            var keyConfiguration = new CertificateConfiguration
            {
                CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\DuckAir.csr",
                CertificateFileName = @"C:\Pluralsight\Test\Keys\DuckAir.cer",
                KeyLabel = "DuckAirlinesKey",
                KeystoreFileName = @"C:\Pluralsight\Test\Keys\DuckAir.key",
                PrivateKeyPassword = "QuackQuack",
                DistinguishedName = new DistinguishedName
                {
                    CommonName = "Flight Ops",
                    OrganizationalUnit = "Security",
                    Organization = "Duck Airlines",
                    Locality = "Cleveland",
                    State = "OH",
                    Country = "US"
                },
                SigningKeyLabel = "Cleveland",
                SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ClevelandIca.key",
                SigningKeyPassword = "P@ssw0rd"
            };
            Key.GenerateKeyPair(keyConfiguration);
            var certificateAuthority = new CertificateAuthority();
            certificateAuthority.SubmitCertificateRequest(@"C:\Pluralsight\Test\Keys\Duckair.csr");
            certificateAuthority.IssueCertificate(keyConfiguration);
        }

        //[TestMethod]
        //public void TestRevoke()
        //{
        //    var cert = new Certificate();
        //    cert.CreateRevocationRequest(@"C:\Pluralsight\Test\Keys\DuckAir.cer", @"C:\Pluralsight\Test\Keys\DuckAir.crlq");
        //}
    }
}