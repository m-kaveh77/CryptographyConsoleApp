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
                Console.WriteLine("------------------- Hash algorithms -------------------");
                Console.WriteLine();
                Console.WriteLine("1. MD5");
                Console.WriteLine("2. SHA");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------");

                Console.Write("Please select your algorithm: ");

                string? algorithm = Console.ReadLine();

                if(string.IsNullOrEmpty(algorithm))
                {
                    Console.WriteLine("You don't select an algorithm");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                if(algorithm == "1")
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

                if(algorithm == "3")
                {
                    continue;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        case "2":
            break;
        case "3":
            break;
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