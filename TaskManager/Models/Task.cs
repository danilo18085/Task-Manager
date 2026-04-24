using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Task
    {
        [Key]
        public int ID {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string Priority {get; set;}
        public int CreatedBy {get; set;}
        public int? AssignedTo {get; set;}
        public string Status {get; set;}
        public DateTime? DueDate {get; set;}
        public DateTime? UpdatedAt {get; set;}
        public DateTime CreatedAt {get; set;}

    }
}

