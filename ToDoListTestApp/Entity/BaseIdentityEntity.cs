using Microsoft.AspNetCore.Identity;
using ToDoListTestApp.Entity.Interfaces;

namespace ToDoListTestApp.Entity
{
    public abstract class BaseIdentityEntity: IdentityUser<Guid>
    {
        public DateTime CreatedDate { get; set; }
    }
}
