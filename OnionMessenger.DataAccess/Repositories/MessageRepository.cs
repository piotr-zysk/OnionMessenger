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

        public string Test()
        {
            throw new NotImplementedException();
        }
    }
}
