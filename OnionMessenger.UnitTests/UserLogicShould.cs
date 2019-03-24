using Xunit;
using OnionMessenger.Logic;
using Moq;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.Webapi.Logic;
using OnionMessenger.Domains;

namespace OnionMessenger.UnitTests
{
    public class UserLogicShould
    {
       
        IUserLogic ul;
        public UserLogicShould()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            
            userRepository.Setup(x => x.GetByLogin(It.IsAny<string>())).Returns(new User() { Id = 2, Login = "user1" });
            userRepository.Setup(x => x.GetByLogin("user1")).Returns(new User() { Id = 1, Login = "user1" });

            this.ul = new UserLogic(userRepository.Object);
        }
      

        [Fact]
        
        public void PassingTest()
        {
            var user = ul.GetByLoginAsync("user2");           


            Assert.Equal(2, user?.Id);            
        }

        

    }
}
