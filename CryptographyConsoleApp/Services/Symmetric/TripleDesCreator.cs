using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CryptographyConsoleApp.Services.Symmetric
{
    public static class TripleDesCreator
    {
        public static void Encrypt(string filePath)
        {
            try
            {
                var outputFile = filePath + ".tripledes";
                var keyFile = filePath + ".key";

                var tripleDes = TripleDES.Create();

                tripleDes.GenerateIV();
                tripleDes.GenerateKey();

                var keyHolder = new KeyHolder
                {
                    IV = tripleDes.IV,
                    Key = tripleDes.Key,
                };

                var json = JsonSerializer.Serialize(keyHolder);
                File.WriteAllText(keyFile, json);

                var fileContent = File.ReadAllText(filePath);
                var fileContentBytes = Encoding.UTF8.GetBytes(fileContent);
                using var fileStream = File.Create(outputFile);
                using var cryptoStream = new CryptoStream(fileStream, tripleDes.CreateEncryptor(tripleDes.Key, tripleDes.IV), CryptoStreamMode.Write);
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

                var tripleDes = TripleDES.Create();

                tripleDes.Key = keyModel.Key;
                tripleDes.IV = keyModel.IV;

                tripleDes.Mode = CipherMode.CBC;
                tripleDes.Padding = PaddingMode.PKCS7;

                using var fileStream = File.Open(filePath, FileMode.Open);
                using var cryptoStream = new CryptoStream(fileStream, tripleDes.CreateDecryptor(tripleDes.Key, tripleDes.IV), CryptoStreamMode.Read);
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
