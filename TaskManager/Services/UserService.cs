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
using BCrypt.Net;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly TaskDbContext _context;
        public UserService(TaskDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUser(DTOUserRegister user)
        {
            var user_check = await _context.Users.Where(p => user.Username == p.Username).FirstOrDefaultAsync();
            if(user_check != null)
                return false;
            
            var mail_check = await _context.Users.Where(p => user.Email == p.Email).FirstOrDefaultAsync();
            if(mail_check != null)
                return false;
            
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            User us = new User();
            us.Username = user.Username;
            us.Email = user.Email;
            us.Password = hashedPassword;
            us.Role = "Regular";
            us.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(us);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Login(string username, string password)
        {
            var storedPassword = await _context.Users.Where(x => x.Username == username).Select(p => p.Password).FirstOrDefaultAsync();

            if(storedPassword == null)
                return false;
            
            if(!BCrypt.Net.BCrypt.Verify(password, storedPassword))
                return false;

            return true; 
        }
    }
}