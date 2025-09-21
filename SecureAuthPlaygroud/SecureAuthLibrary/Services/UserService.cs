using System;
using System.Security.Cryptography;
using SecureAuthLibrary.Models;
using SecureAuthLibrary.Hashing;

namespace SecureAuthLibrary.Services
{
    /// <summary>
    /// Provides user registration and authentication services.
    /// </summary>
    public class UserService
    {
        private readonly IHasher _hasher;
        private readonly string? _pepper;

        public UserService(IHasher hasher, string? pepper = null)
        {
            _hasher = hasher;
            _pepper = pepper; // optional secret added for extra security
        }

        /// <summary>
        /// Registers a new user with hashed password.
        /// </summary>
        public void Register(string username, string password)
        {
            var salt = GenerateSalt();
            var hashedPassword = _hasher.Hash(password + (_pepper ?? ""), salt);
            Database.SaveUser(new User(username, salt, hashedPassword));
            Console.WriteLine($"User '{username}' registered successfully.");
        }

        /// <summary>
        /// Logs in a user. Returns true if password is correct.
        /// </summary>
        public bool Login(string username, string password)
        {
            var user = Database.GetUser(username);
            if (user == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login failed: user not found");
                Console.ResetColor();
                return false;
            }

            bool valid = _hasher.Verify(password + (_pepper ?? ""), user.Salt, user.HashedPassword);

            if (valid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login failed: wrong password");
            }

            Console.ResetColor();
            return valid;
        }


        /// <summary>
        /// Generates a secure random salt.
        /// </summary>
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}
