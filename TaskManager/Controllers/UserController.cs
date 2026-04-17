
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

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

        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            try
            {
                Context.Users.Add(user);
                await Context.SaveChangesAsync();
                return Ok($"User je dodat! ID je: {user.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
