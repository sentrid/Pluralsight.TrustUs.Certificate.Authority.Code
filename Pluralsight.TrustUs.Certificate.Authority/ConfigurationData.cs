namespace Pluralsight.TrustUs
{
    public static class ConfigurationData
    {
        public static CertificateAuthorityConfiguration Root => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\ca.cer",
            KeystoreFileName = @"C:\Pluralsight\Keys\ca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "US",
                State = "OH",
                Locality = "Cleveland",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Root Certificate"
            },
            KeyLabel = "Root",
            PrivateKeyPassword = "P@ssw0rd",
            CertificateStoreFilePath = @"C:\Pluralsight\Keys\TrustUsStore.db",
            CertificateStoreOdbcName = "TrustUs",
            CertStoreUrl = @"http://certs.trustusca.net",
            OcspUrl = @"http://ocsp.trustusca.net",
            RevocationListUrl = @"http://crl.trustusca.net"
        };

        public static CertificateAuthorityConfiguration Cleveland => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\clevelandIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Keys\clevelandIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "US",
                State = "OH",
                Locality = "Cleveland",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Cleveland Certificate"
            },
            KeyLabel = "Cleveland",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Mumbai => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\mumbaiIca.csr",
            KeystoreFileName = @"C:\Pluralsight\Keys\mumbaiIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "IN",
                State = "Maharashtra",
                Locality = "Mumbai",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Mumbai Certificate"
            },
            KeyLabel = "Mumbai",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Berlin => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\berlinIca.csr",
            KeystoreFileName = @"C:\Pluralsight\Keys\berlinIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "DE",
                Locality = "Berlin",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Berlin Certificate"
            },
            KeyLabel = "Berlin",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Santiago => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\santiagoIca.csr",
            KeystoreFileName = @"C:\Pluralsight\Keys\santiagoIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "CL",
                Locality = "Santiago",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Santiago Certificate"
            },
            KeyLabel = "Santiago",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Moscow => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\moscowIca.csr",
            KeystoreFileName = @"C:\Pluralsight\Keys\moscowIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "RU",
                State = "Moscow Oblast",
                Locality = "Moscow",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Santiago Certificate"
            },
            KeyLabel = "Moscow",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Sydney => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\sydneyIca.csr",
            KeystoreFileName = @"C:\Pluralsight\Keys\sydneyIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "AU",
                State = "New South Wales",
                Locality = "Sydney",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Sydney Certificate"
            },
            KeyLabel = "Sydney",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Capetown => new CertificateAuthorityConfiguration
        {
            CertificateFileName = @"C:\Pluralsight\Keys\capeTownIca.csr",
            KeystoreFileName = @"C:\Pluralsight\Keys\capeTownIca.key",
            DistinguishedName = new DistinguishedName
            {
                Country = "ZA",
                State = "Western Cape",
                Locality = "Cape Town",
                Organization = "Trust Us",
                OrganizationalUnit = "Certificates",
                CommonName = "Cape Town Certificate"
            },
            KeyLabel = "Cape Town",
            PrivateKeyPassword = "P@ssw0rd",
            SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };
    }
}