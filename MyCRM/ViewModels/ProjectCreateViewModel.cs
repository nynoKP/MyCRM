using MyCRM.Models;

namespace MyCRM.ViewModels
{
    public class ProjectCreateViewModel
    {
        public IEnumerable<CRMUser> Users { get; set; }
        public IEnumerable<Contragent> Contragents { get; set; }
        public Project EditProject { get; set; }
    }
}
