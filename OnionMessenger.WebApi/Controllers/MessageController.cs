using OnionMessenger.Logic.Repositories;
using OnionMessenger.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;
using OnionMessenger.Infrastructure;

namespace OnionMessenger.WebApi.Controllers
{
    [JwtAuthentication]
    public class MessageController : ApiController
    {
        readonly IMessageRepository _messageRepository;

        
        public MessageController(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }
       

        // GET api/values
       
        public IEnumerable<string> Get()
        {
            string test = PasswordHash.Encrypt(_messageRepository.Test());
            string token_user = User.Identity.Name;
            return new string[] { "value1", "value2", token_user, test };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
