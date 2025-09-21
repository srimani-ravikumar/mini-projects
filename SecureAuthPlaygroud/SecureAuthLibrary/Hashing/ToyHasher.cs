using System;
using System.Text;

namespace SecureAuthLibrary.Hashing
{
    /// <summary>
    /// Deliberately weak hashing algorithm for educational purposes.
    /// Demonstrates why naive methods are insecure.
    /// </summary>
    public class ToyHasher : IHasher
    {
        public string Hash(string password, string salt)
        {
            var combined = password + salt;
            var reversed = new string(combined.Reverse().ToArray());
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(reversed));
        }

        public bool Verify(string password, string salt, string hashedPassword)
        {
            return Hash(password, salt) == hashedPassword;
        }
    }
}
