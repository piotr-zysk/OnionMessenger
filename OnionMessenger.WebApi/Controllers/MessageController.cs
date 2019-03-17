using OnionMessenger.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using OnionMessenger.Logic;
using AutoMapper;
using OnionMessenger.WebApi.ViewModels;
using OnionMessenger.Logic.DTO;
using OnionMessenger.Domains;

namespace OnionMessenger.WebApi.Controllers
{
    [JwtAuthentication]
    public class MessageController : ApiController
    {
        IMessageLogic _messageLogic;
        IMapper _mapper;

        public MessageController(IMessageLogic messageLogic, IMapper mapper)
        {
            this._messageLogic = messageLogic;
            this._mapper = mapper;
        }

        
        // GET api/values
       
        public IEnumerable<string> Get()
        {
            //string test = PasswordHash.Encrypt(_messageRepository.Test());
            //string token_user = User.Identity.Name;
            return new string[] { "value1", "value2"};
        }

        // GET api/message/{id}
        public Message Get(int id)
        {
            return _messageLogic.GetById(id);
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

        [Route("api/message/send")]
        [HttpPost]
        public IHttpActionResult Send([FromBody]MessageInput value)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return BadRequest(errorMessages);

            }

            var messageDTO = _mapper.Map<MessageDTO>(value);

            var result = _messageLogic.Send(messageDTO);

            if (result.Success)
            {
                /*
                var userRegistered = new UserRegistered()
                {
                    Title = "User registered successfully.",
                   // Id = value.Id,
                    Login = value.Login,
                    FirstName = value.FirstName,
                    LastName=value.LastName
                };
                */

                //var userRegistered = _mapper.Map<UserRegistered>(result.Value);
                return Created("", result.Value);  //dodaj uri                    
            }
            else
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
