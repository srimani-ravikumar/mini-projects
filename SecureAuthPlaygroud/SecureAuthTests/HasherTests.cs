using SecureAuthLibrary.Hashing;

namespace SecureAuthPlayground.Tests
{
    public class BcryptHasherTests
    {
        [Theory]
        [InlineData("password123", "salt1")]
        [InlineData("!@#$%^", "randomSalt")]
        [InlineData("", "emptyPass")]
        public void Hash_Verify_Should_Work(string password, string salt)
        {
            var hasher = new BcryptHasher();
            var hash = hasher.Hash(password, salt);

            Assert.True(hasher.Verify(password, salt, hash));
            Assert.False(hasher.Verify("wrong", salt, hash));
        }
    }
}
