
namespace DTO
{
    public class DTOUpdateTask
    {
        public int TaskID {get; set;}
        public string? Description {get; set;}
        public string? Priority {get; set;}
        public string? Status {get; set;}
        public DateTime? DueDate {get; set;}
        public int? AssignedTo {get; set;}
    }
}