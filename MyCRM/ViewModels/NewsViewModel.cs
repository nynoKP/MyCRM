using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.ViewModels
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
    }
}
