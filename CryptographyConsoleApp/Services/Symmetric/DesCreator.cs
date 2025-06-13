using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CryptographyConsoleApp.Services.Symmetric
{
    public static class DesCreator
    {
        public static void Encrypt(string filePath)
        {
            try
            {
                var outputFile = filePath + ".des";
                var keyFile = filePath + ".key";

                var des = DES.Create();

                des.GenerateIV();
                des.GenerateKey();

                var keyHolder = new KeyHolder
                {
                    IV = des.IV,
                    Key = des.Key,
                };

                var json = JsonSerializer.Serialize(keyHolder);
                File.WriteAllText(keyFile, json);

                var fileContent = File.ReadAllText(filePath);
                var fileContentBytes = Encoding.UTF8.GetBytes(fileContent);
                using var fileStream = File.Create(outputFile);
                using var cryptoStream = new CryptoStream(fileStream, des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write);
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

                var des = DES.Create();

                des.Key = keyModel.Key;
                des.IV = keyModel.IV;

                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                using var fileStream = File.Open(filePath, FileMode.Open);
                using var cryptoStream = new CryptoStream(fileStream, des.CreateDecryptor(des.Key, des.IV), CryptoStreamMode.Read);
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
