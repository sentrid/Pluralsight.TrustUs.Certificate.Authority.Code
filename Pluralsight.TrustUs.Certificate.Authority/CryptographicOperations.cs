using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs
{
    public class CryptographicOperations
    {
        public byte[] Encrypt(string plainText)
        {
            var keystore = crypt.KeysetOpen(crypt.UNUSED, crypt.KEYSET_ODBC, "TrustUs", crypt.KEYOPT_READONLY);
            crypt.GetPublicKey(keystore, crypt.KEYID_NAME, "Flight Ops");

            crypt.CreateEnvelope(crypt.UNUSED, crypt.FORMAT_CRYPTLIB);
            
            // 70
            return null;
        }
    }
}