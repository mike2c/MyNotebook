using System.Collections.Generic;

namespace Core.Models
{
    public class PaginatedResult<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
