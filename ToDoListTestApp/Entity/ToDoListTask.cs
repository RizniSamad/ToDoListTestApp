using System.ComponentModel.DataAnnotations.Schema;
using ToDoListTestApp.Entity.Base;
using ToDoListTestApp.Entity.Enum;
using ToDoListTestApp.Entity.Interfaces;

namespace ToDoListTestApp.Entity
{
    public class ToDoListTask : BaseEntity, IAggregatedRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ToDoListTaskStatus Status { get; set; }

        public Guid ToDoListId { get; set; }
        [ForeignKey("ToDoListId")]
        public ToDoList ToDoList { get; set; }
    }
}
