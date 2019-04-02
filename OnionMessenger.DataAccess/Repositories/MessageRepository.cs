using System;
using System.Collections.Generic;
using OnionMessenger.DataAccess.DB;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;
using System.Linq;
using OnionMessenger.Logic.DTO;
using System.Diagnostics;

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
            IQueryable<MessageRecipient> recipientMessages = _dataContext.Set<MessageRecipient>().Where(mr => mr.UserId == Id);
            IQueryable<Message> messages = _dataContext.Set<Message>().Join(recipientMessages, m => m.Id, rm => rm.MessageId, (m, rm) => m);

            return messages.ToList();
        }

        public MessageDTO GetMessageWithRecipientIds(int messageID)
        {
            throw new NotImplementedException();
        }

        public MessageWithRecpientNamesDTO GetMessageWithRecipientNames(int messageID)
        {
            /*
             * logowanie aktywnosci EF do zmienej ss
            string ss = "";
            _dataContext.Database.Log = s => ss+=s;
            */

            return _dataContext.Set<Message>().Where(m => m.Id == messageID)
                    .GroupJoin(
                        _dataContext.Set<MessageRecipient>(),
                        m => m.Id,
                        mr => mr.MessageId,
                        (m, mr) => new MessageWithRecpientNamesDTO()
                        {
                            Title = m.Title,
                            Content=m.Content,
                            AuthorId=m.AuthorId,
                            TimeCreated=m.TimeCreated,
                            IsActive=m.IsActive,
                            Priority=m.Priority,
                            Recipients = mr.Join(
                                _dataContext.Set<User>(),
                                mri => mri.UserId,
                                u => u.Id,
                                (mri, u) => new UserDTO()
                                {
                                    FirstName=u.FirstName,
                                    LastName=u.LastName,
                                    Login=u.Login,
                                    Id=u.Id
                                }
                            )
                        }).FirstOrDefault();
                
        }

        public IEnumerable<User> GetRecipients(int messageId)
        {
            var messageRecipients = _dataContext.Set<MessageRecipient>().Where(mr => mr.MessageId == messageId);
            var recipients = _dataContext.Set<User>().Join(messageRecipients, r => r.Id, mr => mr.UserId, (r, mr) => r);
            return recipients.ToList();
        }
    }
}
