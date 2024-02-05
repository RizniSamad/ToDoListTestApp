using System.ComponentModel.DataAnnotations.Schema;
using ToDoListTestApp.Entity.Enum;

namespace ToDoListTestApp.Entity
{
    public class ToDoListTask : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ToDoListTaskStatus Status { get; set; }

        public int ToDoListId { get; set; }
        [ForeignKey("ToDoListId")]
        public ToDoList ToDoList { get; set; }
    }
}
