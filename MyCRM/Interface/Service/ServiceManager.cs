using MyCRM.Services;

namespace MyCRM.Interface.Service
{
    public interface IServiceManager
    {
        ContragentService Contragent { get; }
        NewsService News { get; }
        ProjectService Project { get; }
        TaskService Task { get; }
        UserService User { get; }
    }
}
