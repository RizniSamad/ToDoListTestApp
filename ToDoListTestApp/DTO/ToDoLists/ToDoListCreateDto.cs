using System.ComponentModel.DataAnnotations;
using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.DTO.ToDoLists
{
    public class ToDoListCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
