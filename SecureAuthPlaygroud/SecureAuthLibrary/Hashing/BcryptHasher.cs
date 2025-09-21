using BCrypt.Net;

namespace SecureAuthLibrary.Hashing
{
    /// <summary>
    /// Implements secure hashing using Bcrypt.
    /// </summary>
    public class BcryptHasher : IHasher
    {
        public string Hash(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password + salt);
        }

        public bool Verify(string password, string salt, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, hashedPassword);
        }
    }
}
