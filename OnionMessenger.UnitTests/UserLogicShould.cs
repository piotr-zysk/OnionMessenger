using Xunit;
using OnionMessenger.Logic;
using Moq;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.Webapi.Logic;
using OnionMessenger.Domains;
using System;

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

            var userRepository = new Lazy<IUserRepository>(() => UserRepository.Object);

            this.ul = new UserLogic(userRepository);
        }
      

        [Fact]
        
        public void PassingTest()
        {
            var user = ul.GetByLogin("user1");           


            Assert.Equal(1, user?.Id);            
        }

        

    }
}


/// dodaj testowanie metody asynchronicznej
/// przenies UserLogic i MessageLogic do projektu Logic (usun automapper)
/// 