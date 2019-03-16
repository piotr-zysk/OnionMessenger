using AutoMapper;
using System.Web.Http;
using OnionMessenger.Logic;
using OnionMessenger.Domains;
using OnionMessenger.WebApi.Filters;
using OnionMessenger.WebApi.ViewModels;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using System.Linq;
using System.Web.Http.Results;

namespace OnionMessenger.WebApi.Controllers
{
    [JwtAuthentication]
    public class UserController : ApiController
    {
        IUserLogic _userLogic;
        IMapper _mapper;

        public UserController(IUserLogic userLogic, IMapper mapper)
        {
            this._userLogic = userLogic;
            this._mapper = mapper;
        }

        [Route("api/user/get/{id}")]
        [HttpGet]
        public User Get(int id)
        {
            return _userLogic.GetById(id);
        }

        [Route("api/user/getbylogin/{login}")]
        [HttpGet]
        public User GetByLogin(string login)
        {
            return _userLogic.GetByLogin(login);
        }

        [Route("api/user/register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]UserToRegister value)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return BadRequest(errorMessages);
                    
            }

            var user = _mapper.Map<User>(value);

            var result = _userLogic.Register(user);

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

                var userRegistered = _mapper.Map<UserRegistered>(result.Value);
                return Created("", userRegistered);  //dodaj uri                    
            }
            else
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
