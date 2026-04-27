using DTO;
using Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _context;

        public TaskService(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTask(DTOCreateTask task)
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
            
            _context.Tasks.Add(ta);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> UpdateTask(DTOUpdateTask task)
        {
            var ta = await _context.Tasks.Where(t => t.ID == task.TaskID).FirstOrDefaultAsync();
            if(ta == null)
                return false;
            
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
            _context.Tasks.Update(ta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTask(int TaskID)
        {
            var ta = await _context.Tasks.Where(t => t.ID == TaskID).FirstOrDefaultAsync();
            if(ta == null)
                return false;
            
            _context.Tasks.Remove(ta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddComment(Comment comm)
        {
            _context.Comments.Add(new Comment {TaskID = comm.TaskID, AuthorID = comm.AuthorID, Body = comm.Body, CreatedAt = DateTime.UtcNow});
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> ListComments(int id_taska)
        {
            var lista = await _context.Comments.Where(p => id_taska == p.TaskID).ToListAsync();

            return lista;
        }
    }
}