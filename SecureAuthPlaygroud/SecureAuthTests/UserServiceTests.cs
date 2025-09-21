using SecureAuthLibrary.Hashing;
using SecureAuthLibrary.Services;

namespace SecureAuthPlayground.Tests
{
    public class UserServiceTests
    {
        public UserServiceTests()
        {
            Database.Clear(); // clean DB before each test
        }

        [Fact]
        public void Register_And_Login_Should_Succeed()
        {
            var service = new UserService(new BcryptHasher());
            service.Register("user1", "pass123");
            Assert.True(service.Login("user1", "pass123"));
        }

        [Fact]
        public void Login_Should_Fail_WrongPassword()
        {
            var service = new UserService(new BcryptHasher());
            service.Register("user2", "pass123");
            Assert.False(service.Login("user2", "wrong"));
        }

        [Fact]
        public void Login_Should_Fail_UserNotExist()
        {
            var service = new UserService(new BcryptHasher());
            Assert.False(service.Login("unknown", "any"));
        }
    }
}
