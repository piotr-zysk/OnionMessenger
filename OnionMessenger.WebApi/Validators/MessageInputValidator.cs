using FluentValidation;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.DataAccess.Repositories;
using OnionMessenger.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionMessenger.WebApi.Validators
{
    public class MessageInputValidator : AbstractValidator<MessageInput>
    {
        private readonly IUserRepository userRepository;

        public MessageInputValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();

            
            RuleFor(x => x.TimeCreated).NotEmpty().WithMessage("Incorrect value of TimeCreated");

                                 
            RuleFor(x => x.Priority).NotNull().Must(property => { if (property <= 10) return true; else return false; }).WithMessage("Acceptable values of Priority: 1 - 10");
 
            RuleFor(x => x.UserId).Must(UserExists).WithMessage("User does not exist");

            RuleFor(x => x.Recipients).Custom((list, context) =>
            {
                var nonExistingRecipients = new List<int>();
                User user;
                foreach (var i in list)
                {
                    user = userRepository.GetById(i);
                    if (user == null) nonExistingRecipients.Add(i);
                }

                if (nonExistingRecipients.Count > 0)
                    context.AddFailure($"{string.Join(",", nonExistingRecipients)} - recipients do not exist.");
                
            });
                
            

            //zmien na custom, i do WithMessage dodaj wszystkie znalezione zle wartosci Recipientow
            //przenies walidacje bazy do osobnych fukcji
            // zaprogramouj dopisywanie recipientow do bazy

        }

        private bool UserExists(int userId)
        {
            User user = userRepository.GetById(userId);
            if (user == null)
                return false;
            else
                return true;

        }
    }
}