using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs.Tests
{
    [TestClass]
    public class CryptographicOperationsTests
    {
        [TestInitialize]
        public void InitializeTests()
        {
            crypt.Init();
        }

        [TestCleanup]
        public void TerminateTests()
        {
            crypt.End();
        }

        [TestMethod]
        public void TestEncrypt()
        {
            var ops = new CryptographicOperations();
            var encrypt = ops.Encrypt("I am a little teapot.");
            var data = ops.Decrypt(encrypt);
        }

        public void TestDecrypt()
        {
            var ops = new CryptographicOperations();
            
        }
    }
}