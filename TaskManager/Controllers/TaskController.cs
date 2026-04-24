
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
    public class TaskController : ControllerBase
    {
        public TaskDbContext Context { get; set; }

        public TaskController(TaskDbContext context)
        {
            Context = context;
        }

        [Route("CreateTask")]
        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody] DTOCreateTask task)
        {
            try
            {
                Models.Task ta = new Models.Task();
                ta.Title = task.Title;
                ta.Description = task.Description;
                ta.Priority = task.Priority;
                ta.CreatedBy = task.CreatedBy;
                ta.Status = task.Status;
                ta.DueDate = task.DueDate;
                ta.CreatedAt = DateTime.UtcNow;
                ta.UpdatedAt = null;
                ta.AssignedTo = null;
                
                Context.Tasks.Add(ta);
                await Context.SaveChangesAsync();
                return Ok($"User je uspesno dodat!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("UpdateTask")]
        [HttpPut]
        public async Task<ActionResult> UpdateTask([FromBody] DTOUpdateTask task)
        {
            try
            {
                var ta = Context.Tasks.Where(t => t.ID == task.TaskID).FirstOrDefault();
                if(task.Description != null)
                    ta.Description = task.Description;
                if(task.Priority != null)
                    ta.Priority = task.Priority;
                if(task.Status != null)
                    ta.Status = task.Status;
                if(task.DueDate != null)
                    ta.DueDate = task.DueDate;
                if(task.AssignedTo != null)
                    ta.AssignedTo = task.AssignedTo;
                
                ta.UpdatedAt = DateTime.UtcNow;

                Context.Tasks.Update(ta);
                await Context.SaveChangesAsync();
                return Ok("Task je uspesno azuriran");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DeleteTask")]
        [HttpDelete]
        public async Task<ActionResult> DeleteTask(int TaskID)
        {
            try
            {
                var ta = Context.Tasks.Where(t => t.ID == TaskID).FirstOrDefault();

                if(ta != null)

                Context.Tasks.Remove(ta);
                await Context.SaveChangesAsync();
                return Ok("Task je uspesno obrisan");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddComment")]
        [HttpPost]
        public async Task<ActionResult> AddComment([FromBody] Comment comm)
        {
            Context.Comments.Add(new Comment {TaskID = comm.TaskID, AuthorID = comm.AuthorID, Body = comm.Body, CreatedAt = DateTime.UtcNow});
            await Context.SaveChangesAsync();
            return Ok("Uspesno je dodat komentar");
        }

        [Route("ListComments")]
        [HttpGet]
        public async Task<ActionResult> ListComments(int id_taska)
        {
            var lista = await Context.Comments.Where(p => id_taska == p.TaskID).ToListAsync();
            //foreach(var elem in lista)
                //Console.WriteLine(elem.Body);

            return Ok(lista);
        }
    }

}
