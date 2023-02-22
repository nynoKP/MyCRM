using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.ViewModels
{
    public class ContragentViewModel
    {
        public IEnumerable<Contragent> Contragents { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
    }
}
