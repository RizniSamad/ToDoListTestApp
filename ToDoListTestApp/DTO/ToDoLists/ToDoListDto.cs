namespace ToDoListTestApp.DTO.ToDoLists
{
    public class ToDoListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AppUserId { get; set; }
        public string AppUser { get; set; }
    }
}
