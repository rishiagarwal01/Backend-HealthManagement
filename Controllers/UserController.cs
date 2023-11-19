using HealthManagementBackend.Models;
using HealthManagementBackend.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthManagementBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService usersService;

        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return usersService.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = usersService.GetById(id);
            if (user == null)
            {
                return NotFound($"user with Id = {id}not found");
            }
            return user;
        }

        // POST api/<UsersController>


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(User users)
        {
            users.Id = ObjectId.GenerateNewId().ToString();
            var registeredUser = await usersService.Register(users);
            return Ok(registeredUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(User users)
        {
            var loginUser = await usersService.Login(users.Email, users.Password);
            if (loginUser == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(loginUser);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User users)
        {
            var existingUser = usersService.GetById(id);

            if (existingUser == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            usersService.Update(id, users);

            return NoContent();
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = usersService.GetById(id);
            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            usersService.Delete(user.Id);

            return Ok($"User with Id = {id} deleted");
        }
    }
}

