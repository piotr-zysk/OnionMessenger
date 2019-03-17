using System;
using System.Collections.Generic;
using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using System.Linq;


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
            var recipientMessages = _dataContext.Set<MessageRecipient>().Where(mr => mr.UserId == Id);
            var messages = _dataContext.Set<Message>().Join(recipientMessages, m => m.Id, rm => rm.MessageId, (m, rm) => m);

            return messages.ToList();
        }

        public IEnumerable<User> GetRecipients(int messageId)
        {
            var messageRecipients = _dataContext.Set<MessageRecipient>().Where(mr => mr.MessageId == messageId);
            var recipients = _dataContext.Set<User>().Join(messageRecipients, r => r.Id, mr => mr.UserId, (r, mr) => r);
            return recipients.ToList();
        }
    }
}
