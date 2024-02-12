using System.ComponentModel.DataAnnotations;

namespace ToDoListTestApp.Entity.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
