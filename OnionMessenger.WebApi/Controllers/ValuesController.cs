using OnionMessenger.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace OnionMessenger.WebApi.Controllers
{
    [JwtAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values
       
        public IEnumerable<string> Get()
        {
            string token_user = User.Identity.Name;
            return new string[] { "value1", "value2", token_user };
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
