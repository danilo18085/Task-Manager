
namespace DTO
{
    public class DTOCreateTask
    {
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Priority {get; set;} = string.Empty;
        public int CreatedBy {get; set;}
        public string Status {get; set;} = string.Empty;
        public DateTime? DueDate {get; set;}
    }
}