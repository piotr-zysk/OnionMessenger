using System;
using System.Collections.Generic;
using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;


namespace OnionMessenger.DataAccess.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(OMDBContext dataConetxt) : base(dataConetxt)
        {
        }

        public void AddRecipient(MessageRecipient messageRecipient)
        {
            _dataContext.Set<MessageRecipient>().Add(messageRecipient);
        }

        public IEnumerable<Message> GetAllByRecipient(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetRecipients(int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
