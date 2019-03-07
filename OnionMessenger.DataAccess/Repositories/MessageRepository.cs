using System;
using System.Collections.Generic;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;


namespace OnionMessenger.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public string Test()
        {
            return "test";
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
