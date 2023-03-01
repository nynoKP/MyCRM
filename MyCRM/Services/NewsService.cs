using MyCRM.Filters;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class NewsService
    {
        private readonly IRepositoryManager _repository;
        public NewsService(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }

        public NewsViewModel GetAll(int page)
        {
            var filter = new PaginationFilter(_repository.News.Count(), page);
            var viewModel = new NewsViewModel()
            {
                PaginationFilter = filter,
                News = _repository.News.GetAll(filter)
            };
            return viewModel;
        }

        public News GetById(int id)
        {
            return _repository.News.GetById(id);
        }

        public void Update(News news)
        {
            news.Author = _repository.Users.GetById(news.Author.Id);
            _repository.News.Update(news);
            _repository.Save();
        }

        public void Create(News news, string creatorId)
        {
            news.CreatedDate = DateTime.Now;
            news.Author = _repository.Users.GetById(creatorId);
            _repository.News.Create(news);
            _repository.Save();
        }
    }
}
