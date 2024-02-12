using ToDoListTestApp.Entity.Base;
using ToDoListTestApp.Entity.Enum;
using ToDoListTestApp.Entity.Interfaces;

namespace ToDoListTestApp.Entity
{
    public class AppUser: BaseIdentityEntity, IAggregatedRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserGender Gender { get; set; }

        public IReadOnlyList<ToDoList> ToDoLists { get; set; }
    }
}
