using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class PaginatedResult<T>
    {
        public int PageIndex { get; }
        public int ItemsPerPage { get; }
        public int TotalItems { get; }
        public int TotalPages { get; }
        public IEnumerable<T> Data { get; set; }
        
        public PaginatedResult(int currentPage, int itemsPerPage, int totalItems, IEnumerable<T> data)
        {
            Data = data;
            
            PageIndex = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);
        }
        
        public bool HasNext()
        {
            return PageIndex < TotalPages;
        }

        public bool HasPrevious()
        {
            return PageIndex > 1;
        }

    }
}
