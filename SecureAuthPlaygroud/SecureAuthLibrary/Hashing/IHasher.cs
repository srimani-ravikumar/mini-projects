namespace SecureAuthLibrary.Hashing
{
    /// <summary>
    /// Standard interface for all hashing algorithms.
    /// </summary>
    public interface IHasher
    {
        /// <summary>
        /// Hashes the password with provided salt.
        /// </summary>
        string Hash(string password, string salt);

        /// <summary>
        /// Verifies the password against the hashed password.
        /// </summary>
        bool Verify(string password, string salt, string hashedPassword);
    }
}
