using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Comment
    {
        [Key]
        public int ID {get; set;}
        public int TaskID {get; set;}
        public int AuthorID {get; set;}
        public string Body {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        
    }
}