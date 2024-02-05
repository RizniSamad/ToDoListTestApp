
namespace ToDoListTestApp.Helper
{
    public class PaginatedResponce<T>
    {
        public PaginatedResponce(IReadOnlyList<T> data, int count, int currentPage, int pageSize, bool success)
        {
            Data = data;
            TotalCount = count;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Success = success;
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
    }
}
