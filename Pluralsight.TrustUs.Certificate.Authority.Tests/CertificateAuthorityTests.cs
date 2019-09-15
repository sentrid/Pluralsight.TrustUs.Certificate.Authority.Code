using System.Collections.Generic;
using System.IO;
using cryptlib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pluralsight.TrustUs.Certificate.Authority.Tests
{
    [TestClass]
    public class CertificateAuthorityTests
    {
        [TestInitialize]
        public void InitializeTests()
        {
            if (Directory.Exists(@"C:\Pluralsight\Test\Keys"))
            {
                Directory.Delete(@"C:\Pluralsight\Test\Keys", true);
            }

            Directory.CreateDirectory(@"C:\Pluralsight\Test\Keys");

            crypt.Init();
        }

        [TestCleanup]
        public void TerminateTests()
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
    }
}