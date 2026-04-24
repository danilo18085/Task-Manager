
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using DTO;
using Microsoft.AspNetCore.Identity;    

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public TaskDbContext Context { get; set; }

        public UserController(TaskDbContext context)
        {
            Context = context;
        }

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] DTOUserRegister user)
        {
            try
            {
                var hasher = new PasswordHasher<object>();
                string hashedPassword = hasher.HashPassword(null, user.Password);

                User us = new User();
                us.Username = user.Username;
                us.Email = user.Email;
                us.Password = hashedPassword;
                us.Role = "Regular";
                us.CreatedAt = DateTime.UtcNow;

                //Console.WriteLine(us.Username + " " + us.Email + " " + us.Password + " " + us.CreatedAt);
                Context.Users.Add(us);
                await Context.SaveChangesAsync();
                return Ok($"User je uspesno dodat!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult> Login(string username, string password)
        {
            try{
            var hasher = new PasswordHasher<object>();
            var sifra_vracena = await Context.Users.Where(x => x.Username == username).Select(p => p.Password).FirstOrDefaultAsync();
            //Console.WriteLine(sifra_vracena);
            var result = hasher.VerifyHashedPassword(
                null,
                sifra_vracena,
                password
            );

            if (result == PasswordVerificationResult.Success)
                Console.WriteLine("Password je ok");

            return Ok(); 
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
