using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StatusChange
    {
        [Key]
        public int ID {get; set;}
        public int TaskID {get; set;}
        public string NewStatus {get; set;}
        public string OldStatus {get; set;}
        public int ChangedBy {get; set;}
        public DateTime ChangedAt {get; set;}

    }
}