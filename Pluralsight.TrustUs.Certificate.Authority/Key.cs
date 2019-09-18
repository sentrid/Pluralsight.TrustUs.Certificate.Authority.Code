using Pluralsight.TrustUs.DataStructures;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs
{
    public static class Key
    {
        /// <summary>
        ///     This method generates a 2048 bit key pair using the RSA algorithm. Key pair
        ///     configuration values are passed in via the key configuration parameter.
        /// 
        ///     Key pair topics  are covered in the "The Public Private Key Pair" module including:
        ///     The fundamentals
        ///     The math to calculate a key pair
        ///     Storing Keys
        /// </summary>
        /// <param name="keyConfiguration">The key configuration.</param>
        public static void GenerateKeyPair(KeyConfiguration keyConfiguration)
        {
            // Cryptlib uses a sort of 'container' called a 'context' to store all of the
            // keying material and configuration items needed to generate a key pair. Ultimately
            // the key pair itself is generated within the context.
            var keyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);

            // The key pair requires a label to find
            crypt.SetAttributeString(keyPair, crypt.CTXINFO_LABEL, keyConfiguration.KeyLabel);
            crypt.SetAttribute(keyPair, crypt.CTXINFO_KEYSIZE, 2048 / 8);
            crypt.GenerateKey(keyPair);
            var keyStore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_FILE, keyConfiguration.KeystoreFileName,
                crypt.KEYOPT_CREATE);
            crypt.AddPrivateKey(keyStore, keyPair, keyConfiguration.PrivateKeyPassword);
            crypt.KeysetClose(keyStore);

            var certClass = new Certificate();
            certClass.CreateSigningRequest(keyConfiguration, keyPair);

            crypt.DestroyContext(keyPair);
        }
    }
}