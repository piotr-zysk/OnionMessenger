using OnionMessenger.Domains;
using OnionMessenger.Logic.DTO;

namespace OnionMessenger.Logic
{
    public interface IMessageLogic
    {
        Result<MessageDTO> Send(MessageDTO messageDTO);        

        Message GetById(int id);       

    }
}
