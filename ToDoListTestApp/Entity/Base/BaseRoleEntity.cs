using Microsoft.AspNetCore.Identity;

namespace ToDoListTestApp.Entity.Base
{
    public abstract class BaseRoleEntity : IdentityRole<Guid>
    {
        public DateTime CreatedDate { get; set; }
    }
}
