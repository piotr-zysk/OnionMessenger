using FluentValidation;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.DataAccess.Repositories;
using OnionMessenger.WebApi.ViewModels;

namespace OnionMessenger.WebApi.Validators
{
    public class UserToRegisterValidator : AbstractValidator<UserToRegister>
    {
        private readonly IUserRepository userRepository;

        public UserToRegisterValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty");            
            RuleFor(x => x.Password).NotNull().Length(6, 20);
            RuleFor(x => x.Age).InclusiveBetween(10, 99);
            RuleFor(x => x.Login).NotNull().Length(4, 10).Must((root, property, context) =>
            {
                User user = userRepository.GetByLogin(property);
                if (user != null)
                    return false;
                else
                    return true;
            }).WithMessage("User already exists");
                
        }
    }
}