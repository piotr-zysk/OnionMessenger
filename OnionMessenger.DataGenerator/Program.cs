using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionMessenger.Domains;
using OnionMessenger.DataAccess;
using OnionMessenger.Logic;
using Bogus;
using Bogus.DataSets;
using OnionMessenger.DataAccess.DB;
using OnionMessenger.DataAccess.Repositories;
using OnionMessenger.Infrastructure;
using OnionMessenger.Logic.Repositories;

namespace OnionMessenger.DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ProduceFakeData();
        }

        public enum Gender
        {
            Male=0,
            Female=1
        }

        public static void ProduceFakeData()
        {
            string locale = "pl";

            List<User> users = GetUsers(locale);

            var repo = new UserRepository(new OMDBContext());
            for (var i = 0; i < users.Count; i++)
            {

                users[i].Password = PasswordHash.Encrypt(users[i].Password);
                if (users[i].Login.Length < 4) users[i].Login = users[i].Login.PadRight(4, '_');
                Console.WriteLine($"{users[i].FirstName} {users[i].LastName}, age:{users[i].Age} login:{users[i].Login} pwd:{users[i].Password}");
                repo.Add(users[i]);
            }

            repo.SaveChanges();

            List<Message> messages = GetMessages(locale, users);

            var repo2 = new MessageRepository(new OMDBContext());
            for (var i = 0; i < messages.Count; i++)
            {

                Console.WriteLine($"T:{messages[i].Title} {messages[i].AuthorId}");
                repo2.Add(messages[i]);
            }
            repo2.SaveChanges();

            List<MessageRecipient> messageRecipients = GetMessageRecipients(locale, users, messages);

            for (var i = 0; i < messageRecipients.Count; i++)
            {
                Console.WriteLine($"MR:{messageRecipients[i].MessageId}/{messageRecipients[i].UserId} {messageRecipients[i].Status}");
                repo2.AddRecipient(messageRecipients[i]);
            }
            repo2.SaveChanges();

        }

        private static List<MessageRecipient> GetMessageRecipients(string locale, List<User> users, List<Message> messages)
        {
            return new Faker<MessageRecipient>(locale)
               .RuleFor(mr => mr.MessageId, (f, p) => f.PickRandom(messages).Id)
               .RuleFor(mr => mr.UserId, (f, p) => f.PickRandom(users).Id)
               .RuleFor(mr => mr.Status, (f, p) => f.Random.Byte(0, 2))
               .Generate(20)
               .GroupBy(x => new { x.MessageId, x.UserId }, (key, group) => new MessageRecipient() { MessageId = key.MessageId, UserId = key.UserId, Status = group.Select(y => y.Status).FirstOrDefault() })
               .OrderBy(x => x.MessageId)
               .ThenBy(x => x.UserId)
               .ToList();
        }

        private static List<Message> GetMessages(string locale, List<User> users)
        {
            return new Faker<Message>(locale)
                .RuleFor(m => m.AuthorId, (f, p) => f.PickRandom(users).Id)
                .RuleFor(m => m.IsActive, (f, p) => f.Random.Bool())
                .RuleFor(m => m.Priority, (f, p) => f.Random.Byte(1, 9))
                .RuleFor(m => m.TimeCreated, (f, p) => f.Date.Past(5))
                .RuleFor(m => m.TimeModified, (f, p) => p.TimeCreated.AddDays(1))
                .RuleFor(m => m.Title, (f, p) => f.Hacker.IngVerb())
                .RuleFor(m => m.User, (f, p) => f.PickRandom(users))
                .RuleFor(m => m.Content, (f, p) => f.Hacker.Phrase().Substring(0, 20))
                .Generate(10);
        }

        private static List<User> GetUsers(string locale)
        {
            var users = new Faker<User>(locale)
                //.StrictMode(true)
                .RuleFor(u => u.Age, (f, u) => f.Random.Byte(18, 99))
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName((Bogus.DataSets.Name.Gender)0))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName((Bogus.DataSets.Name.Gender)0))
                .RuleFor(u => u.Login, (f, u) => f.Person.UserName)
                .RuleFor(u => u.Password, (f, u) => f.Hacker.IngVerb())
                .Generate(10);
            return users;
        }
    }
}
