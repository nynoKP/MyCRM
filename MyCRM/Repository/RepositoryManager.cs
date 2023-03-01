using MyCRM.Data;
using MyCRM.Interface.Repository;

namespace MyCRM.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<ContragentRepository> _contragentRepository;
        private readonly Lazy<NewsRepository> _newsRepository;
        private readonly Lazy<ProjectRepository> _projectRepository;
        private readonly Lazy<TaskRepository> _taskRepository;
        private readonly Lazy<UserRepository> _userRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _contragentRepository = new Lazy<ContragentRepository>(() => new ContragentRepository(context));
            _newsRepository = new Lazy<NewsRepository>(()=>new NewsRepository(context));
            _projectRepository = new Lazy<ProjectRepository>(() => new ProjectRepository(context));
            _taskRepository = new Lazy<TaskRepository>(() => new TaskRepository(context));
            _userRepository = new Lazy<UserRepository>(() => new UserRepository(context));
        }

        public ContragentRepository Contragent => _contragentRepository.Value;
        public NewsRepository News => _newsRepository.Value;
        public ProjectRepository Projects => _projectRepository.Value;
        public TaskRepository Tasks => _taskRepository.Value;
        public UserRepository Users => _userRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
