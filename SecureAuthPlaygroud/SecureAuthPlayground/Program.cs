using System;
using SecureAuthLibrary.Services;
using SecureAuthLibrary.Hashing;

namespace SecureAuthConsole
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== SecureAuth Playground Demo ===");

            // Step 1: Choose hashing algorithm
            IHasher hasher = ChooseHasher();

            var userService = new UserService(hasher, pepper: "SuperSecretPepper123");

            // Step 2: Interactive menu
            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter username: ");
                        var regUser = Console.ReadLine();
                        Console.Write("Enter password: ");
                        var regPass = ReadPassword();
                        userService.Register(regUser!, regPass!);
                        break;

                    case "2":
                        Console.Write("Enter username: ");
                        var loginUser = Console.ReadLine();
                        Console.Write("Enter password: ");
                        var loginPass = ReadPassword();
                        userService.Login(loginUser!, loginPass!);
                        break;

                    case "3":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid option. Try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        /// <summary>
        /// Lets user choose the hashing algorithm to demo.
        /// </summary>
        private static IHasher ChooseHasher()
        {
            while (true)
            {
                Console.WriteLine("\nSelect hashing algorithm to use:");
                Console.WriteLine("1. Bcrypt (Secure, widely used)");
                Console.WriteLine("2. Argon2 (Secure, memory-hard)");
                Console.WriteLine("3. Toy Hasher (Insecure, educational)");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": return new BcryptHasher();
                    case "2": return new Argon2Hasher();
                    case "3": return new ToyHasher();
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        /// <summary>
        /// Reads password without echoing characters to console
        /// </summary>
        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*"); // show asterisks
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b"); // erase last *
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}
