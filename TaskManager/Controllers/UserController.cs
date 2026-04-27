
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using DTO;
using Services;
using Microsoft.AspNetCore.Identity;    

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] DTOUserRegister user)
        {
            var success = await _userService.RegisterUser(user);

            if(!success)
                return BadRequest("Doslo je greske pri registrovanju");

            return Ok("Uspesno registrovanje");
        }

        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult> Login(string username, string password)
        {
            var success = await _userService.Login(username, password);

            if(!success)
                return BadRequest("Doslo je greske pri logovanju");

            return Ok("Login uspesan!");
        }
    }
}
