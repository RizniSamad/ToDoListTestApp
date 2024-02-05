using System.ComponentModel.DataAnnotations;
using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.DTO.AppUsers
{
    public class AppUserCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public UserGender Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
