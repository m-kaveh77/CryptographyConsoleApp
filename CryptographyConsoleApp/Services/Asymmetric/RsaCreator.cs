using System.Security.Cryptography;
using System.Text;

namespace CryptographyConsoleApp.Services.Asymmetric
{
    public static class RsaCreator
    {
        public static string Encrypt(string keyPath, string text)
        {
            try
            {
                using var rsa = RSACryptoServiceProvider.Create(2048);

                if (!File.Exists(keyPath))
                {
                    File.WriteAllText($"{keyPath}\\publickey.xml", rsa.ToXmlString(false));
                    File.WriteAllText($"{keyPath}\\privatekey.xml", rsa.ToXmlString(true));
                }

                rsa.FromXmlString(File.ReadAllText($"{keyPath}\\privatekey.xml"));

                var fileContentBytes = Encoding.UTF8.GetBytes(text);

                var encrypted = Convert.ToBase64String(rsa.Encrypt(fileContentBytes, RSAEncryptionPadding.Pkcs1));

                return encrypted;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Decrypt(string privateKeyPath, string text)
        {
            try
            {
                using var rsa = RSACryptoServiceProvider.Create(2048);

                rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var encryptedbytes = Convert.FromBase64String(text);
                var decryptedBytes = rsa.Decrypt(encryptedbytes, RSAEncryptionPadding.Pkcs1);
                var decrypted = Encoding.UTF8.GetString(decryptedBytes);

                return decrypted;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
