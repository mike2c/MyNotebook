using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class PaginatedResult<T>
    {
        public readonly int PageIndex;
        public readonly int ItemsPerPage;
        public readonly int TotalItems;
        public readonly int TotalPages;
        public readonly IEnumerable<T> Data;
        
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
