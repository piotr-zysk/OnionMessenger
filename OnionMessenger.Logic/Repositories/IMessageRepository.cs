using System.Collections.Generic;
using OnionMessenger.Domains;
using OnionMessenger.Logic.DTO;

namespace OnionMessenger.Logic.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        void AddRecipient(MessageRecipient messageRecipient);        

        IEnumerable<Message> GetAllByRecipient(int Id);

        IEnumerable<User> GetRecipients(int messageId);

        MessageWithRecpientNamesDTO GetMessageWithRecipientNames(int messageID);

        MessageDTO GetMessageWithRecipientIds(int messageID);

    }
}
