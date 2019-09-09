namespace Pluralsight.TrustUs
{
    /// <summary>
    /// Class CertificateConfiguration.
    /// </summary>
    public class CertificateConfiguration
    {
        /// <summary>
        /// Gets or sets the name of the signing key file.
        /// </summary>
        /// <value>The name of the signing key file.</value>
        public string SigningKeyFileName { get; set; }

        /// <summary>
        /// Gets or sets the signing key label.
        /// </summary>
        /// <value>The signing key label.</value>
        public string SigningKeyLabel { get; set; }

        /// <summary>
        /// Gets or sets the signing key password.
        /// </summary>
        /// <value>The signing key password.</value>
        public string SigningKeyPassword { get; set; }

        /// <summary>
        /// Gets or sets the private key password.
        /// </summary>
        /// <value>The private key password.</value>
        public string PrivateKeyPassword { get; set; }

        /// <summary>
        /// Gets or sets the key label.
        /// </summary>
        /// <value>The key label.</value>
        public string KeyLabel { get; set; }

        /// <summary>
        /// Gets or sets the name of the keystore file.
        /// </summary>
        /// <value>The name of the keystore file.</value>
        public string KeystoreFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the certificate file.
        /// </summary>
        /// <value>The name of the certificate file.</value>
        public string CertificateFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the distinguished.
        /// </summary>
        /// <value>The name of the distinguished.</value>
        public DistinguishedName DistinguishedName { get; set; }
    }
}