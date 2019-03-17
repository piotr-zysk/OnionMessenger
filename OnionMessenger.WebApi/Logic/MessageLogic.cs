using System;
using System.Collections.Generic;
using AutoMapper;
using OnionMessenger.Domains;
using OnionMessenger.Logic;
using OnionMessenger.Logic.DTO;
using OnionMessenger.Logic.Repositories;
using OnionMessenger.WebApi.ViewModels;

namespace OnionMessenger.Webapi.Logic
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


            if (result.Success) return Result.Ok<MessageDTO>(messageDTO);
            else return Result.Failure<MessageDTO>(result.Errors);
        }
    }
}
