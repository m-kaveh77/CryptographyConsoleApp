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
            break;
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
            break;
        default:
            break;
    }
}