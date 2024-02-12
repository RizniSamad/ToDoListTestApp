using System.ComponentModel.DataAnnotations;
using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.DTO.ToDoLists
{
    public class ToDoListUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
