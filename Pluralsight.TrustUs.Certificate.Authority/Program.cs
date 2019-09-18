﻿using System;
using System.Collections.Generic;
using Pluralsight.TrustUs.DataStructures;
using Pluralsight.TrustUs.Libraries;

namespace Pluralsight.TrustUs
{
    /// <summary>
    ///     Class Program.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for Program
    internal class Program
    {
        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Main
        private static void Main(string[] args)
        {
            crypt.Init();
            var trustUsCertificateAuthority = new CertificateAuthoritySetup();
            var intermediateCertificateAuthorities = new List<CertificateConfiguration>()
            {
                ConfigurationData.Berlin,
                ConfigurationData.Capetown,
                ConfigurationData.Cleveland,
                ConfigurationData.Moscow,
                ConfigurationData.Mumbai,
                ConfigurationData.Santiago,
                ConfigurationData.Sydney
            };

            #region commented icas

            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\clevelandIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\clevelandIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "US",
            //        State = "OH",
            //        Locality = "Cleveland",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Cleveland Certificate"
            //    },
            //    KeyLabel = "Cleveland",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});

            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\mumbaiIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\mumbaiIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "IN",
            //        State = "Maharashtra",
            //        Locality = "Mumbai",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Mumbai Certificate"
            //    },
            //    KeyLabel = "Mumbai",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});
            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\berlinIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\berlinIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "DE",
            //        Locality = "Berlin",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Berlin Certificate"
            //    },
            //    KeyLabel = "Berlin",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});
            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\santiagoIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\santiagoIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "CL",
            //        Locality = "Santiago",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Santiago Certificate"
            //    },
            //    KeyLabel = "Santiago",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});
            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\moscowIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\moscowIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "RU",
            //        State = "Moscow Oblast",
            //        Locality = "Moscow",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Santiago Certificate"
            //    },
            //    KeyLabel = "Moscow",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});
            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\sydneyIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\sydneyIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "AU",
            //        State = "New South Wales",
            //        Locality = "Sydney",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Sydney Certificate"
            //    },
            //    KeyLabel = "Sydney",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});
            //intermediateCertificateAuthorities.Add(new CertificateConfiguration
            //{
            //    CertificateRequestFileName = @"C:\Pluralsight\Keys\capeTownIca.csr",
            //    KeystoreFileName = @"C:\Pluralsight\Keys\capeTownIca.key",
            //    DistinguishedName = new DistinguishedName
            //    {
            //        Country = "ZA",
            //        State = "Western Cape",
            //        Locality = "Cape Town",
            //        Organization = "Trust Us",
            //        OrganizationalUnit = "Certificates",
            //        CommonName = "Cape Town Certificate"
            //    },
            //    KeyLabel = "Cape Town",
            //    PrivateKeyPassword = "P@ssw0rd",
            //    SigningKeyFileName = @"C:\Pluralsight\Keys\ca.key",
            //    SigningKeyLabel = "Root",
            //    SigningKeyPassword = "P@ssw0rd"
            //});

            #endregion

            var done = false;
            do
            {
                switch (DisplayMenu())
                {
                    case 1:
                        trustUsCertificateAuthority.Install(ConfigurationData.Root, intermediateCertificateAuthorities);
                        break;
                    case 5:
                        done = true;
                        break;
                }
            } while (!done);

            crypt.End();
        }

        /// <summary>
        ///     Displays the menu.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for DisplayMenu
        private static int DisplayMenu()
        {
            Console.WriteLine("TrustUs Certificate Authority");
            Console.WriteLine();
            Console.WriteLine("1. Install Certificate Authority");
            Console.WriteLine("2. Create Key Pair");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}