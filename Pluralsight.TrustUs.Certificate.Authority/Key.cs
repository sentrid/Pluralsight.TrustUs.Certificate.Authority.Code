using cryptlib;

namespace Pluralsight.TrustUs
{
    public class Key
    {
        public void GenerateKeyPair(string label, string password, string csrFileName, string keyFileName)
        {
            var caKeyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);

            crypt.SetAttributeString(caKeyPair, crypt.CTXINFO_LABEL, "");
            crypt.SetAttribute(caKeyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(caKeyPair);
        }
    }
}