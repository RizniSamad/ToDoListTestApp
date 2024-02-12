using Microsoft.AspNetCore.Identity;

namespace ToDoListTestApp.Entity
{
    public abstract class BaseRoleEntity: IdentityRole<Guid>
    {
        public DateTime CreatedDate { get; set; }
    }
}
