namespace Pluralsight.TrustUs
{
    public class CertificateConfiguration
    {
        public string SigningKeyFileName { get; set; }

        public string SigningKeyLabel { get; set; }

        public string SigningKeyPassword { get; set; }

        public string PrivateKeyPassword { get; set; }

        public string KeyLabel { get; set; }

        public string KeystoreFileName { get; set; }

        public string CertificateFileName { get; set; }

        public DistinguishedName DistinguishedName { get; set; }
    }
}