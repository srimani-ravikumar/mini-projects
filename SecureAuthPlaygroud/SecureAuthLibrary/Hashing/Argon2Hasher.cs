using Isopoh.Cryptography.Argon2;

namespace SecureAuthLibrary.Hashing
{
    /// <summary>
    /// Implements secure hashing using Argon2 algorithm.
    /// </summary>
    public class Argon2Hasher : IHasher
    {
        public string Hash(string password, string salt)
        {
            return Argon2.Hash(password + salt);
        }

        public bool Verify(string password, string salt, string hashedPassword)
        {
            return Argon2.Verify(hashedPassword, password + salt);
        }
    }
}
