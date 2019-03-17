using FluentValidation;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.DataAccess.Repositories;
using OnionMessenger.WebApi.ViewModels;
using System;
using System.Collections.Generic;

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
 
            RuleFor(x => x.UserId).Must((root, property, context) =>
            {
                User user = userRepository.GetById(property);
                if (user == null)
                    return false;
                else
                    return true;
            }).WithMessage("User does not exist");

            RuleFor(x => x.Recipients).Must((root, property, context) =>
            {
                var nonExistingRecipients = new List<int>();
                User user;
                foreach (var i in property)
                {
                    user = userRepository.GetById(i);
                    if (user == null) nonExistingRecipients.Add(i);
                }

                if (nonExistingRecipients.Count == 0) return true;
                else return false;
                
            }).WithMessage("Recipient does not exist");

            //zmien na custom, i do WithMessage dodaj wszystkie znalezione zle wartosci Recipientow
            //przenies walidacje bazy do osobnych fukcji
            // zaprogramouj dopisywanie recipientow do bazy

        }
    }
}