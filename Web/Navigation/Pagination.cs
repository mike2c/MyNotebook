using Core.Models;
using System.Text;

namespace Web.Navigation
{
    public class Pagination
    {
        public static PaginationLink GenerateNavigationLinks<T>(PaginatedResult<T> result, int page, string search, string orderBy, string direction)
        {
            PaginationLink links = new PaginationLink();
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(search))
            {
                builder.Append($"&search={search}");
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                builder.Append($"&orderBy={orderBy}");

                if (!string.IsNullOrEmpty(direction))
                {
                    builder.Append($"&direction={direction}");
                }
            }

            string queryVars = builder.ToString();

            if (result.HasNext())
            {
                links.Next = queryVars + $"&page={(page + 1)}";
            }

            if (result.HasPrevious())
            {
                links.Previous = queryVars + $"&page={(page - 1)}";
            }

            return links;
        }
    }
}
