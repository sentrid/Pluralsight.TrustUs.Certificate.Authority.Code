using System.IO;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;

namespace Pluralsight.TrustUs
{
    public class DotNetCrypto
    {
        public static void TestCreateCertSignReq()
        {
            var keyGen = new RsaKeyPairGenerator();
            keyGen.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            keyGen.GenerateKeyPair();
        }

        public static void TestCert()
        {
        }

        public static void TestPrivateKey()
        {
            //var secureString = new SecureString();
            //foreach(var ltr in "P@ssw0rd".ToCharArray())
            //{
            //    secureString.AppendChar(ltr);
            //}

            //var pem = File.ReadAllBytes(@"C:\Pluralsight\Test\Keys\clevelandIca.cer");

            //var privateKeyCert = new X509Certificate2(@"C:\Pluralsight\Test\Keys\clevelandIca.key", secureString, X509KeyStorageFlags.Exportable);

            var textReader =
                new StreamReader(new FileStream(@"C:\Pluralsight\Test\Keys\clevelandica.key", FileMode.Open));
            var pemReader = new PemReader(textReader);
            var pemObject = pemReader.ReadPemObject();

            //var pkCert = new X509Certificate2();
            //pkCert.Import(@"C:\Pluralsight\Test\Keys\clevelandIca.key");
        }

        public static void GenerateKeyPair()
        {
            var keyGenerator = new RsaKeyPairGenerator();
            keyGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair = keyGenerator.GenerateKeyPair();
            var privateKey = keyPair.Private;
            var publicKey = keyPair.Public;

            var x500Name = new X509Name("C=US, ST=OH, L=Cleveland, O=Duck Airlines, OU=Security, CN=Flight Operations");

            var signatureFactory = new Asn1SignatureFactory("SHA512WITHRSA", keyPair.Private);
            var certificateSigningRequest =
                new Pkcs10CertificationRequest(signatureFactory, x500Name, keyPair.Public, null);

            var csrTextWriter = new StringWriter();
            var pemCsrWriter = new PemWriter(csrTextWriter);
            pemCsrWriter.WriteObject(certificateSigningRequest);
            pemCsrWriter.Writer.Flush();
            File.WriteAllText(@"C:\Pluralsight\Test\Keys\FlightOps.csr", csrTextWriter.ToString());

            var pvkTextWriter = new StringWriter();
            var pemPvkWriter = new PemWriter(pvkTextWriter);
            pemPvkWriter.WriteObject(privateKey);
            pemPvkWriter.Writer.Flush();
            File.WriteAllText(@"C:\Pluralsight\Test\Keys\FlightOps.key", pvkTextWriter.ToString());
        }

        //private static string _privateKey;
        //private static string _publicKey;
        //private static UnicodeEncoding _encoder = new UnicodeEncoding();

        //private static void RSA()
        //{
        //    var rsa = new RSACryptoServiceProvider();

        //    _privateKey = rsa.ToXmlString(true);
        //    _publicKey = rsa.ToXmlString(false);

        //    var text = "Test1";
        //    Console.WriteLine("RSA // Text to encrypt: " + text);
        //    var enc = Encrypt(text);
        //    Console.WriteLine("RSA // Encrypted Text: " + enc);
        //    var dec = Decrypt(enc);
        //    Console.WriteLine("RSA // Decrypted Text: " + dec);
        //}

        //public static string Decrypt(string data)
        //{
        //    var rsa = new RSACryptoServiceProvider();
        //    var dataArray = data.Split(new char[] { ',' });
        //    byte[] dataByte = new byte[dataArray.Length];
        //    for (int i = 0; i < dataArray.Length; i++)
        //    {
        //        dataByte[i] = Convert.ToByte(dataArray[i]);
        //    }

        //    rsa.FromXmlString(_privateKey);
        //    var decryptedByte = rsa.Decrypt(dataByte, false);
        //    return _encoder.GetString(decryptedByte);
        //}

        //public static string Encrypt(string data)
        //{
        //    var rsa = new RSACryptoServiceProvider();
        //    rsa.FromXmlString(_publicKey);
        //    var dataToEncrypt = _encoder.GetBytes(data);
        //    var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
        //    var length = encryptedByteArray.Count();
        //    var item = 0;
        //    var sb = new StringBuilder();
        //    foreach (var x in encryptedByteArray)
        //    {
        //        item++;
        //        sb.Append(x);

        //        if (item < length)
        //            sb.Append(",");
        //    }

        //    return sb.ToString();
        //}
    }
}