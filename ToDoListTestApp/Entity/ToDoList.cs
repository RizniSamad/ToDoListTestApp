using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListTestApp.Entity
{
    public class ToDoList : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public IReadOnlyList<ToDoListTask> ToDoListTasks { get; set; }
    }
}
