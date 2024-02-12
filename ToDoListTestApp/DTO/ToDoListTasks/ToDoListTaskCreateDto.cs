using System.ComponentModel.DataAnnotations;
using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.DTO.ToDoListTasks
{
    public class ToDoListTaskCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public ToDoListTaskStatus Status { get; set; }

        [Required]
        public Guid ToDoListId { get; set; }
    }
}
