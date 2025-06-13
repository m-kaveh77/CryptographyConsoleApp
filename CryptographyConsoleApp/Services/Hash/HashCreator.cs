using System.Security.Cryptography;
using System.Text;

namespace CryptographyConsoleApp.Services.Hash
{
    public static class HashCreator
    {
        public static string MD5Hasher(string text)
        {
            try
            {
                var md5Hasher = MD5.Create();
                var passwordBytes = Encoding.UTF8.GetBytes(text);
                var md5HashedBytes = md5Hasher.ComputeHash(passwordBytes);
                var md5HashedString = Convert.ToBase64String(md5HashedBytes);

                return md5HashedString;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string SHAHasher(string text)
        {
            try
            {
                var sha256Hasher = SHA256.Create();
                //var sha512Hasher = SHA512.Create();
                var passwordBytes = Encoding.UTF8.GetBytes(text);
                var hashedSha256Bytes = sha256Hasher.ComputeHash(passwordBytes);
                //var hashedSha512Bytes = sha512Hasher.ComputeHash(passwordBytes);
                var hashedSha256String = Convert.ToBase64String(hashedSha256Bytes);
                //var hashedSha512String = Convert.ToBase64String(hashedSha512Bytes);

                return hashedSha256String;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
