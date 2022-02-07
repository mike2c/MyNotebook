namespace Core.Models
{
    public class Pagination
    {
        public const int DefaultSize = 12;
        public const string DefaultOrdering = "title";
        public const string DefaultDirection = "asc";

        public int Page { get; set; } = 1 ;
        public int Size { get; set; } = DefaultSize;
        public string Search { get; set; } = string.Empty;
        public string OrderBy { get; set; } = DefaultOrdering;
        public string Direction { get; set; } = DefaultDirection;
        
    }
}
