using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic
{
    public interface IMessageLogic
    {
        Message Send(Message message);

        

        Message GetById(int id);

        

    }
}
