using Models;
using DTO;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Route("CreateTask")]
        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody] DTOCreateTask task)
        {
            var success = await _taskService.CreateTask(task);

            if(!success)
                return BadRequest("Doslo je greske pri kreiranju taska!");

            return Ok("Task je uspesno kreiran!");
        }
        
        [Route("UpdateTask")]
        [HttpPut]
        public async Task<ActionResult> UpdateTask([FromBody] DTOUpdateTask task)
        {
            var success = await _taskService.UpdateTask(task);

            if(!success)
                return BadRequest("Doslo je greske pri azuriranju taska!");

            return Ok("Task je uspesno azuriran!");
        }

        [Route("DeleteTask")]
        [HttpDelete]
        public async Task<ActionResult> DeleteTask(int TaskID)
        {
            var success = await _taskService.DeleteTask(TaskID);

            if(!success)
                return BadRequest("Doslo je greske pri brisanju taska!");

            return Ok("Task je uspesno obrisan!");
        }
        [Route("AddComment")]
        [HttpPost]
        public async Task<ActionResult> AddComment([FromBody] Comment comm)
        {
            var success = await _taskService.AddComment(comm);

            if(!success)
                return BadRequest("Doslo je greske pri dodavanju komentara!");

            return Ok("Komentar je uspesno dodat!");
        }

        [Route("ListComments")]
        [HttpGet]
        public async Task<ActionResult> ListComments(int id_taska)
        {
            var lista = await _taskService.ListComments(id_taska);

            if(lista == null)
                return BadRequest("Doslo je do greske pri vracanju komentara");
            
            return Ok(lista);
        }
    }

}
