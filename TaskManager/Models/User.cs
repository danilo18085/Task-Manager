using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int ID {get; set;}

        public string Username {get; set;} = string.Empty;
        public string Password {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string Role {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
} 