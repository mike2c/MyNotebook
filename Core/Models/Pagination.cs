namespace Core.Models
{
    public class Pagination
    {
        public const int DefaultSize = 8;
        
        public int Page { get; set; } = 1 ;
        public int Size { get; set; } = DefaultSize;
        public string Search { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        
    }
}
