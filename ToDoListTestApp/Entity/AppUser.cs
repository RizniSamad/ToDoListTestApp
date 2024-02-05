using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.Entity
{
    public class AppUser: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserGender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IReadOnlyList<ToDoList> ToDoLists { get; set; }
    }
}
