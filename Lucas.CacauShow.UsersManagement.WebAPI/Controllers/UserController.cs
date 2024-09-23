using Lucas.CacauShow.UsersManagement.Contracts.Services;
using Lucas.CacauShow.UsersManagement.Models.Requests;
using Lucas.CacauShow.UsersManagement.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lucas.CacauShow.UsersManagement.WebAPI.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<UserResponse> Get(int id)
        {
            return await _userService.GetUser(id);
        }

        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost]
        public async Task Post(UserRequest user)
        {
            try
            {
                await _userService.InsertUser(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task Put(int id, UserRequest user)
        {
            await _userService.UpdateUser(id, user);
        }

        [HttpDelete("{idUser}")]
        public async Task Delete(int idUser)
        {
            await _userService.DeleteUser(idUser);
        }
    }
}
