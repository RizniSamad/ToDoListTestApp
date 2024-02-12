using System.ComponentModel.DataAnnotations;

namespace ToDoListTestApp.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
