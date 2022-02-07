using Core.Models;
using System.Text;

namespace Web.Navigation
{
    public class ListNavigation
    {
        public static NavigationLink GenerateLinks<T>(PaginatedResult<T> result, Pagination pagination)
        {
            NavigationLink links = new NavigationLink();
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(pagination.Search))            
                builder.Append($"&search={pagination.Search}");
            
            if (!string.IsNullOrEmpty(pagination.OrderBy))
            {
                builder.Append($"&orderBy={pagination.OrderBy}");

                if (!string.IsNullOrEmpty(pagination.Direction))                
                    builder.Append($"&direction={pagination.Direction}");                
            }

            string queryVars = builder.ToString();

            if (result.HasNext())            
                links.Next = queryVars + $"&page={(pagination.Page + 1)}";            

            if (result.HasPrevious())            
                links.Previous = queryVars + $"&page={(pagination.Page - 1)}";            

            return links;
        }
    }
}
