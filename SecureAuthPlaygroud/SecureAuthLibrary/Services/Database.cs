using SecureAuthLibrary.Models;

namespace SecureAuthLibrary.Services
{
    /// <summary>
    /// Simulates a database using in-memory dictionary for demo purposes.
    /// </summary>
    public static class Database
    {
        private static Dictionary<string, User> users = new Dictionary<string, User>();

        /// <summary>
        /// Saves a user into the database.
        /// </summary>
        public static void SaveUser(User user)
        {
            users[user.Username] = user;
        }

        /// <summary>
        /// Retrieves a user by username.
        /// Returns null if user does not exist.
        /// </summary>
        public static User? GetUser(string username)
        {
            users.TryGetValue(username, out var user);
            return user;
        }

        /// <summary>
        /// Clears all users (useful for testing).
        /// </summary>
        public static void Clear()
        {
            users.Clear();
        }
    }
}
