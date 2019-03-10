using AutoMapper;
using System.Web.Http;
using OnionMessenger.Logic;
using OnionMessenger.Domains;
using OnionMessenger.WebApi.Filters;
using OnionMessenger.WebApi.ViewModels;

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
        public IHttpActionResult Register([FromBody]User value)
        {
            var success = _userLogic.Register(value);

            if (success)
            {
                /*
                var userRegistered = new UserRegistered()
                {
                    Title = "User registered successfully.",
                    Id = value.Id,
                    Login = value.Login,
                    FirstName = value.FirstName,
                    LastName=value.LastName
                };
                */

                var userRegistered = _mapper.Map<UserRegistered>(value);
                return Ok(userRegistered);
            }
            else
                return BadRequest("User registration failed. Login already exists.");
        }
    }
}
