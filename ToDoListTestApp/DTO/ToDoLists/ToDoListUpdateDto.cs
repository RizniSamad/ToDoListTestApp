using System.ComponentModel.DataAnnotations;
using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.DTO.ToDoLists
{
    public class ToDoListUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
