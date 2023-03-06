using MyCRM.Models;
using MyCRM.Repository;

namespace MyCRM.Interface.Repository
{
    public interface IRepositoryManager
    {
        ContragentRepository Contragent { get; }
        NewsRepository News { get; }
        ProjectRepository Projects { get; }
        TaskRepository Tasks { get; }
        TaskStateRepository TaskStatuses { get; }
        UserRepository Users { get; }
        public void Save();
    }
}
