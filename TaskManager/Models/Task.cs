using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Task
    {
        [Key]
        public int ID {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Priority {get; set;} = string.Empty;
        public int CreatedBy {get; set;}
        public int? AssignedTo {get; set;}
        public string Status {get; set;} = string.Empty;
        public DateTime? DueDate {get; set;}
        public DateTime? UpdatedAt {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    }
}

