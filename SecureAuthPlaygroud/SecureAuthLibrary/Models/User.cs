namespace SecureAuthLibrary.Models
{
    /// <summary>
    /// Represents a user in the authentication system.
    /// Stores username, unique salt, and hashed password.
    /// </summary>
    public class User
    {
        public string Username { get; }
        public string Salt { get; }
        public string HashedPassword { get; }

        public User(string username, string salt, string hashedPassword)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Salt = salt ?? throw new ArgumentNullException(nameof(salt));
            HashedPassword = hashedPassword ?? throw new ArgumentNullException(nameof(hashedPassword));
        }
    }
}
