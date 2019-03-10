using OnionMessenger.Domains;
using OnionMessenger.Logic;
using OnionMessenger.WebApi.Helpers;
using System.Net;
using System.Web.Http;

namespace OnionMessenger.WebApi.Controllers
{
    public class TokenController : ApiController
    {
        IUserLogic _userLogic;

        public TokenController(IUserLogic userLogic)
        {
            this._userLogic = userLogic;
        }

        // This is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [Route("api/token")]
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult GetToken([FromBody]UserCredentials userCredentials)
        {
            if (_userLogic.ValidateCredentials(userCredentials))
            {
                return Ok(JwtManager.GenerateToken(userCredentials.Login));
            }
            
            return StatusCode(HttpStatusCode.Unauthorized);
            
        }

    }
}