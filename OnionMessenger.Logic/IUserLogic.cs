using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionMessenger.Domains;

namespace OnionMessenger.Logic
{
    public interface IUserLogic
    {
        bool Register(User User);

        bool ValidateCredentials(string Login, string Password);

        User GetById(int id);
    }
}
