using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;


namespace OnionMessenger.WebApi.ViewModels
{
    [Validator(typeof(UserToRegisterValidator))]
    public class UserToRegister
    {        

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Login { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
    }

    public class UserToRegisterValidator : AbstractValidator<UserToRegister>
    {
        public UserToRegisterValidator()
        {            
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty");
            RuleFor(x => x.Login).NotNull().Length(4, 10);
            RuleFor(x => x.Password).NotNull().Length(6, 20);
            RuleFor(x => x.Age).InclusiveBetween(10, 99);
        }
    }
}