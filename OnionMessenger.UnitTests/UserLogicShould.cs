using Xunit;
using OnionMessenger.Logic;
using Moq;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.Webapi.Logic;
using OnionMessenger.Domains;
using System;
using System.Threading.Tasks;

namespace OnionMessenger.UnitTests
{
    public class UserLogicShould
    {
       
        IUserLogic ul;
        public UserLogicShould()
        {
            var UserRepository = new Mock<IUserRepository>();
            
            UserRepository.Setup(x => x.GetByLogin(It.IsAny<string>())).Returns(new User() { Id = 2, Login = "user1" });
            UserRepository.Setup(x => x.GetByLogin("user1")).Returns(new User() { Id = 1, Login = "user1" });

            //compatible with all Moq versions:
            //UserRepository.Setup(x => x.GetByLoginAsync(It.IsAny<string>())).Returns(Task.FromResult(new User() { Id = 2, Login = "user1" }));
            // new Method in Moq 4.2:
            UserRepository.Setup(x => x.GetByLoginAsync(It.IsAny<string>())).ReturnsAsync(new User() { Id = 2, Login = "user1" });

            var userRepository = new Lazy<IUserRepository>(() => UserRepository.Object);

            this.ul = new UserLogic(userRepository);
        }
      

        [Fact]        
        public void GetByLogint()
        {
            var user = ul.GetByLogin("user1");

            Assert.Equal(1, user?.Id);            
        }

        [Fact]
        public async void GetByLoginAsync()
        {
            var user = await ul.GetByLoginAsync("user1");

            Assert.Equal(2, user?.Id);
        }

    }
}


/// dodaj testowanie metody asynchronicznej
/// przenies UserLogic i MessageLogic do projektu Logic (usun automapper)
/// 