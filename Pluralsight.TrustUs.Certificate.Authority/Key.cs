using cryptlib;

namespace Pluralsight.TrustUs
{
    public static class Key
    {
        public static void GenerateKeyPair(KeyConfiguration keyConfiguration)
        {
            var keyPair = crypt.CreateContext(crypt.UNUSED, crypt.ALGO_RSA);
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