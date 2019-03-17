using OnionMessenger.Domains;

namespace OnionMessenger.Logic
{
    public interface IMessageLogic
    {
        Result<Message> Send(Message message);        

        Message GetById(int id);       

    }
}
