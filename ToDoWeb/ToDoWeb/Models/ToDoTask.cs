using System.ComponentModel.DataAnnotations;

namespace ToDoWeb.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Required]
        public string? Heading { get; set; }

        public string? Description { get; set; }

        public string? Recurrence { get; set; }

        [Required]
        public DateOnly TargetDate { get; set; }
    }
}
