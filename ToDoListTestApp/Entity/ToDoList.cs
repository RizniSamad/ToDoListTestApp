using System.ComponentModel.DataAnnotations.Schema;
using ToDoListTestApp.Entity.Base;
using ToDoListTestApp.Entity.Interfaces;

namespace ToDoListTestApp.Entity
{
    public class ToDoList : BaseEntity, IAggregatedRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public IReadOnlyList<ToDoListTask> ToDoListTasks { get; set; }
    }
}
