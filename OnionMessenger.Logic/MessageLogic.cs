using System;
using System.Collections.Generic;
using AutoMapper;
using OnionMessenger.Domains;
using OnionMessenger.Logic.DTO;
using OnionMessenger.Logic.Repositories;

namespace OnionMessenger.Logic
{
    class MessageLogic : IMessageLogic
    {
        IMessageRepository _messageRepository;
        IMapper _mapper;

        public MessageLogic(IMessageRepository messageRepository, IMapper mapper)
        {
            this._messageRepository = messageRepository;
            this._mapper = mapper;
        }

        public IEnumerable<Message> GetAllByRecipient(int Id)
        {
            return _messageRepository.GetAllByRecipient(Id);
        }

        public Message GetById(int id)
        {
            return _messageRepository.GetById(id);
        }

        public Result<MessageDTO> GetMessageWithRecipientIds(int messageId)
        {
            throw new NotImplementedException();
        }

        public Result<MessageWithRecpientNamesDTO> GetMessageWithRecipientNames(int messageId)
        {
            var output = _messageRepository.GetMessageWithRecipientNames(messageId);

            if (output != null)
                return Result.Ok<MessageWithRecpientNamesDTO>(output);
            else
            {
                var error = new ErrorMessage("dbcontext", "Database Access Error");
                var errors = new List<ErrorMessage>() { error };
                return Result.Failure<MessageWithRecpientNamesDTO>(errors);
            }

        }

        public IEnumerable<UserDTO> GetRecipients(int messageId)
        {
                return _mapper.Map<IEnumerable<UserDTO>>(_messageRepository.GetRecipients(messageId));
        }

        public Result<MessageDTO> Send(MessageDTO messageDTO)
        {
            var result = new Result();

            Message message = _mapper.Map<Message>(messageDTO);

                       
            try
            {
                _messageRepository.Add(message);
                foreach (int i in messageDTO.Recipients)
                    _messageRepository.AddRecipient(new MessageRecipient { MessageId = message.Id, UserId = i, Status = 0 });
                _messageRepository.SaveChanges();
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Success = false;
                var error = new ErrorMessage("dbcontext", e.Message);
                result.Errors = new List<ErrorMessage>() { error };
            }

            //messageDTO = _mapper.Map<MessageDTO>(message);  -- w ten sposób otrzymujemy obiekt zgodny ze stanem bazy danych, ale z Recipients==null;
            messageDTO.TimeModified = message.TimeModified;

            if (result.Success) return Result.Ok<MessageDTO>(messageDTO);
            else return Result.Failure<MessageDTO>(result.Errors);
        }
    }
}
