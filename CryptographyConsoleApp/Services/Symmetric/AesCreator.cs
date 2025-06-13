using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CryptographyConsoleApp.Services.Symmetric
{
    public static class AesCreator
    {
        public static void Encrypt(string filePath)
        {
            try
            {
                var outputFile = filePath + ".aes";
                var keyFile = filePath + ".key";

                var aes = Aes.Create();

                aes.GenerateIV();
                aes.GenerateKey();

                var keyHolder = new KeyHolder
                {
                    IV = aes.IV,
                    Key = aes.Key,
                };

                var json = JsonSerializer.Serialize(keyHolder);
                File.WriteAllText(keyFile, json);

                var fileContent = File.ReadAllText(filePath);
                var fileContentBytes = Encoding.UTF8.GetBytes(fileContent);
                using var fileStream = File.Create(outputFile);
                using var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);
                cryptoStream.Write(fileContentBytes, 0, fileContentBytes.Length);
                cryptoStream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Decrypt(string filePath, string keyFile) 
        {
            try
            {
                var keyModel = JsonSerializer.Deserialize<KeyHolder>(File.ReadAllText(keyFile));

                var aes = Aes.Create();
                aes.Key = keyModel.Key;
                aes.IV = keyModel.IV;

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using var fileStream = File.Open(filePath, FileMode.Open);
                using var cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read);
                var streamReader = new StreamReader(cryptoStream);
                var output = streamReader.ReadToEnd();
                File.WriteAllText($"{Path.GetDirectoryName(filePath)}\\decrypted.txt", output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
