using Microsoft.AspNetCore.Identity;
using ToDoListTestApp.Entity.Interfaces;

namespace ToDoListTestApp.Entity.Base
{
    public abstract class BaseIdentityEntity : IdentityUser<Guid>
    {
        public DateTime CreatedDate { get; set; }
    }
}
