using System.ComponentModel.DataAnnotations;

namespace ToDoListTestApp.DTO.ToDoListTasks
{
    public class ToDoListTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int ToDoListId { get; set; }
        public string ToDoList { get; set; }
    }
}
