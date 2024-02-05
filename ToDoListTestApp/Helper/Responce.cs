namespace ToDoListTestApp.Helper
{
    public class Responce<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Responce(T data,bool success, string message, List<string> errors= null) 
        {
            Data = data;
            Success = success;
            Message = message;
            Errors = errors?? new List<string>();
        }
    }
}
