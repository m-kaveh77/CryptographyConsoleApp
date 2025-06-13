using CryptographyConsoleApp.Services.Asymmetric;
using CryptographyConsoleApp.Services.Symmetric;
using System.Security.Cryptography;
using System.Text;

while (true)
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Welcome to Cryptography Console App");
    Console.WriteLine("-----------------------------------------------------------");

    Console.WriteLine();

    Console.WriteLine("------------------- Application options -------------------");
    Console.WriteLine();
    Console.WriteLine("1. Hash functions");
    Console.WriteLine("2. Symmertic algorithms");
    Console.WriteLine("3. Asymmetric algorithms");
    Console.WriteLine("4. Reverse text");
    Console.WriteLine("5. Exit");
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------------------------");

    Console.Write("Please select your option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            {
                Console.Clear();
                Console.WriteLine("------------------- Hash algorithms -----------------------");
                Console.WriteLine();
                Console.WriteLine("1. MD5");
                Console.WriteLine("2. SHA");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------");

                Console.Write("Please select your algorithm: ");

                string? algorithm = Console.ReadLine();

                if (string.IsNullOrEmpty(algorithm))
                {
                    Console.WriteLine("You don't select an algorithm");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                // MD5
                if (algorithm == "1")
                {
                    Console.Write("Enter your text: ");
                    string? text = Console.ReadLine();

                    if (string.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("Text cannot is empty.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    var md5Hasher = MD5.Create();
                    var passwordBytes = Encoding.UTF8.GetBytes(text);
                    var md5HashedBytes = md5Hasher.ComputeHash(passwordBytes);
                    var md5HashedString = Convert.ToBase64String(md5HashedBytes);

                    Console.WriteLine($"Hashed text with MD5: {md5HashedString}");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                // SHA
                if (algorithm == "2")
                {
                    Console.Write("Enter your text: ");
                    string? text = Console.ReadLine();

                    if (string.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("Text cannot is empty.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    var sha256Hasher = SHA256.Create();
                    var sha512Hasher = SHA512.Create();
                    var passwordBytes = Encoding.UTF8.GetBytes(text);
                    var hashedSha256Bytes = sha256Hasher.ComputeHash(passwordBytes);
                    var hashedSha512Bytes = sha512Hasher.ComputeHash(passwordBytes);
                    var hashedSha256String = Convert.ToBase64String(hashedSha256Bytes);
                    var hashedSha512String = Convert.ToBase64String(hashedSha512Bytes);

                    Console.WriteLine($"Hashed text with SHA256: {hashedSha256String}");
                    Console.WriteLine($"Hashed text with SHA512: {hashedSha512String}");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                // Exit
                if (algorithm == "3")
                {
                    continue;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        case "2":
            {
                Console.Clear();
                Console.WriteLine("------------------- Symmetric algorithms -------------------");
                Console.WriteLine();
                Console.WriteLine("1. DES");
                Console.WriteLine("2. Triple DES");
                Console.WriteLine("3. AES");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------");

                Console.Write("Please select your algorithm: ");

                string? algorithm = Console.ReadLine();

                if (string.IsNullOrEmpty(algorithm))
                {
                    Console.WriteLine("You don't select an algorithm");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                // DES
                if (algorithm == "1")
                {
                    Console.Clear();
                    Console.WriteLine("------------------- Symmetric algorithms -------------------");
                    Console.WriteLine();
                    Console.WriteLine("------------------- DES algorithm --------------------------");
                    Console.WriteLine("1. Encrypt");
                    Console.WriteLine("2. Decrypt");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------------");

                    Console.Write("Please select your operation: ");

                    string? operation = Console.ReadLine();

                    // Encrypt
                    if (operation == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Symmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- DES algorithm --------------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Encryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("File path to encrypt (Example: D:\\Temp\\temp.txt): ");

                        string? filePath = Console.ReadLine();

                        if (!Path.Exists(filePath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        DesCreator.Encrypt(filePath);

                        Console.WriteLine("The encrypted with IV and Key file has been created.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Decrypt
                    if (operation == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Symmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- DES algorithm --------------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Decryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("file path to decrypt (Example: D:\\Temp\\temp.txt.des): ");

                        string? filePath = Console.ReadLine();

                        if (!Path.Exists(filePath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Key file to decrypt (Example: D:\\Temp\\temp.txt.key): ");

                        string? keyFile = Console.ReadLine();

                        if (!Path.Exists(keyFile))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        DesCreator.Decrypt(filePath, keyFile);

                        Console.WriteLine("The decrypted file has been created.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Exit
                    if (operation == "3")
                    {
                        continue;
                    }
                }

                // Triple DES
                if (algorithm == "2") 
                {
                    Console.Clear();
                    Console.WriteLine("------------------- Symmetric algorithms -------------------");
                    Console.WriteLine();
                    Console.WriteLine("------------------- Triple DES algorithm -------------------");
                    Console.WriteLine("1. Encrypt");
                    Console.WriteLine("2. Decrypt");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------------");

                    Console.Write("Please select your operation: ");

                    string? operation = Console.ReadLine();

                    // Encrypt
                    if (operation == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Symmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Triple DES algorithm -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Encryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("File path to encrypt (Example: D:\\Temp\\temp.txt): ");

                        string? filePath = Console.ReadLine();

                        if (!Path.Exists(filePath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        TripleDesCreator.Encrypt(filePath);

                        Console.WriteLine("The encrypted with IV and Key file has been created.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Decrypt
                    if (operation == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Symmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Triple DES algorithm -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Decryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("file path to decrypt (Example: D:\\Temp\\temp.txt.tripledes): ");

                        string? filePath = Console.ReadLine();

                        if (!Path.Exists(filePath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Key file to decrypt (Example: D:\\Temp\\temp.txt.key): ");

                        string? keyFile = Console.ReadLine();

                        if (!Path.Exists(keyFile))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        TripleDesCreator.Decrypt(filePath, keyFile);

                        Console.WriteLine("The decrypted file has been created.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Exit
                    if (operation == "3")
                    {
                        continue;
                    }
                }

                // AES
                if (algorithm == "3")
                {
                    Console.Clear();
                    Console.WriteLine("------------------- Symmetric algorithms -------------------");
                    Console.WriteLine();
                    Console.WriteLine("------------------- AES algorithm --------------------------");
                    Console.WriteLine("1. Encrypt");
                    Console.WriteLine("2. Decrypt");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------------");

                    Console.Write("Please select your operation: ");

                    string? operation = Console.ReadLine();

                    // Encrypt
                    if (operation == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Symmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- AES algorithm --------------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Encryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("File path to encrypt (Example: D:\\Temp\\temp.txt): ");

                        string? filePath = Console.ReadLine();

                        if (!Path.Exists(filePath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        AesCreator.Encrypt(filePath);

                        Console.WriteLine("The encrypted with IV and Key file has been created.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Decrypt
                    if (operation == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Symmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- AES algorithm --------------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Decryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("file path to decrypt (Example: D:\\Temp\\temp.txt.aes): ");

                        string? filePath = Console.ReadLine();

                        if (!Path.Exists(filePath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Key file to decrypt (Example: D:\\Temp\\temp.txt.key): ");

                        string? keyFile = Console.ReadLine();

                        if (!Path.Exists(keyFile))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        AesCreator.Decrypt(filePath, keyFile);

                        Console.WriteLine("The decrypted file has been created.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Exit
                    if (operation == "3")
                    {
                        continue;
                    }
                }

                // Exit
                if (algorithm == "4")
                {
                    continue;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        case "3":
            {
                Console.Clear();
                Console.WriteLine("------------------- Asymmetric algorithms -------------------");
                Console.WriteLine();
                Console.WriteLine("1. RSA");
                Console.WriteLine("2. Exit");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------");

                Console.Write("Please select your algorithm: ");

                string? algorithm = Console.ReadLine();

                if (string.IsNullOrEmpty(algorithm))
                {
                    Console.WriteLine("You don't select an algorithm");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                // RSA
                if (algorithm == "1")
                {
                    Console.Clear();
                    Console.WriteLine("------------------- Asymmetric algorithms -------------------");
                    Console.WriteLine();
                    Console.WriteLine("------------------- RSA algorithm --------------------------");
                    Console.WriteLine("1. Encrypt");
                    Console.WriteLine("2. Decrypt");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------------");

                    Console.Write("Please select your operation: ");

                    string? operation = Console.ReadLine();

                    // Encrypt
                    if (operation == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Asymmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- RSA algorithm --------------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Encryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("The path to create public and private key (Example: D:\\Temp): ");

                        string? keyPath = Console.ReadLine();

                        if (!Path.Exists(keyPath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Please enter your text: ");

                        string? text = Console.ReadLine();

                        if (string.IsNullOrEmpty(text))
                        {
                            Console.WriteLine("Text cannot be empty.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        string encrypted = RsaCreator.Encrypt(keyPath, text);

                        Console.WriteLine($"The encrypted your text: {encrypted}");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Decrypt
                    if (operation == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("------------------- Asymmetric algorithms -------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- RSA algorithm --------------------------");
                        Console.WriteLine();
                        Console.WriteLine("------------------- Decryption -----------------------------");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");

                        Console.Write("The private path to decrypt (Example: D:\\Temp\\privatekey.xml): ");

                        string? privateKeyPath = Console.ReadLine();

                        if (!Path.Exists(privateKeyPath))
                        {
                            Console.WriteLine("The path does not exists.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Please enter the encrypted text: ");

                        string? text = Console.ReadLine();

                        if (string.IsNullOrEmpty(text))
                        {
                            Console.WriteLine("The text cannot be empty.");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }

                        string decrypted = RsaCreator.Decrypt(privateKeyPath, text);

                        Console.WriteLine($"The decrypted your text: {decrypted}");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    // Exit
                    if (operation == "3")
                    {
                        continue;
                    }
                }

                // Exit
                if (algorithm == "2")
                {
                    continue;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        case "4":
            {
                Console.Clear();
                Console.WriteLine("Reverse Text: ");
                Console.WriteLine("-----------------------------------------------------------");

                Console.Write("Enter your text: ");
                string? text = Console.ReadLine();

                if (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Text cannot is empty.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                string reversedText = "";
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    reversedText += text[i];
                }

                Console.WriteLine($"Reversed your text: {reversedText}");

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        case "5":
            {
                Console.Clear();
                Console.WriteLine("Good Luck. Buy");
                Console.WriteLine("-----------------------------------------------------------");
                return;
            }
        default:
            break;
    }
}

public class KeyHolder
{
    public byte[]? Key { get; set; }
    public byte[]? IV { get; set; }
}