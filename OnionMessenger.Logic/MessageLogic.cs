using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionMessenger.Domains;
using OnionMessenger.Logic.Repositories;

namespace OnionMessenger.Logic
{
    class MessageLogic : IMessageLogic
    {
        IMessageRepository _messageRepository;

        public MessageLogic(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result<Message> Send(Message message)
        {
            var result = new Result();

            try
            {
                _messageRepository.Add(message);
                _messageRepository.SaveChanges();
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Success = false;
                var error = new ErrorMessage("dbcontext", e.Message);
                result.Errors = new List<ErrorMessage>() { error };
            }


            if (result.Success) return Result.Ok<Message>(message);
            else return Result.Failure<Message>(result.Errors);
        }
    }
}
