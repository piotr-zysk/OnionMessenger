using OnionMessenger.Domains;
using OnionMessenger.Logic.DTO;
using System.Collections.Generic;

namespace OnionMessenger.Logic
{
    public interface IMessageLogic
    {
        Result<MessageDTO> Send(MessageDTO messageDTO);        

        Message GetById(int id);

        IEnumerable<Message> GetAllByRecipient(int Id);

        IEnumerable<UserDTO> GetRecipients(int messageId);

        Result<MessageWithRecpientNamesDTO> GetMessageWithRecipientNames(int messageId);

        Result<MessageDTO> GetMessageWithRecipientIds(int messageId);

    }
}
