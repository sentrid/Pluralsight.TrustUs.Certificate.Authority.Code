using Pluralsight.TrustUs.DataStructures;

namespace Pluralsight.TrustUs.Tests
{
    public static class TestData
    {
        public static CertificateAuthorityConfiguration Root => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\ca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\ca.key",
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
            CertificateStoreFilePath = @"C:\Pluralsight\Test\Keys\TrustUsStore.db",
            CertificateStoreOdbcName = "TrustUsTest",
            CertStoreUrl = @"http://certs.trustusca.net",
            OcspUrl = @"http://ocsp.trustusca.net",
            RevocationListUrl = @"http://crl.trustusca.net"
        };

        public static CertificateAuthorityConfiguration Cleveland => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\clevelandIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\clevelandIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Mumbai => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\mumbaiIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\mumbaiIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Berlin => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\berlinIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\berlinIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Santiago => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\santiagoIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\santiagoIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Moscow => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\moscowIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\moscowIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Sydney => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\sydneyIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\sydneyIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };

        public static CertificateAuthorityConfiguration Capetown => new CertificateAuthorityConfiguration
        {
            CertificateRequestFileName = @"C:\Pluralsight\Test\Keys\capeTownIca.cer",
            KeystoreFileName = @"C:\Pluralsight\Test\Keys\capeTownIca.key",
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
            SigningKeyFileName = @"C:\Pluralsight\Test\Keys\ca.key",
            SigningKeyLabel = "Root",
            SigningKeyPassword = "P@ssw0rd"
        };
    }
}