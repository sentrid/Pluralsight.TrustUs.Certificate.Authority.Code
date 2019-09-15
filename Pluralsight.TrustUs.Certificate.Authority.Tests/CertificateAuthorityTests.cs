using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluralsight.TrustUs.DataStructures;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs.Certificate.Authority.Tests
{
    [TestClass]
    public class CertificateAuthorityTests
    {
        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            if (Directory.Exists(@"C:\Pluralsight\Test\Keys"))
            {
                Directory.Delete(@"C:\Pluralsight\Test\Keys", true);
            }

            Directory.CreateDirectory(@"C:\Pluralsight\Test\Keys");

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
            var certificateAuthority = new CertificateAuthority();



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
            certificateAuthority.Install(TestData.Root, intermediateCertificateAuthorities);
        }

        [TestMethod]
        public void TestSubmitCsr()
        {
            var keyConfiguration = new KeyConfiguration
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
                }
            };
            Key.GenerateKeyPair(keyConfiguration);
            var certificateAuthority = new CertificateAuthority();
            certificateAuthority.SubmitCertificateRequest(keyConfiguration);
        }
    }
}