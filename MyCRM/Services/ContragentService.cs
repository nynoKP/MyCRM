using MyCRM.Filters;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class ContragentService
    {
        public readonly IRepositoryManager _repository;
        public ContragentService(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }

        public ContragentViewModel GetAll(int page)
        {
            var filter = new PaginationFilter(_repository.Contragent.Count(), page);
            var viewModel = new ContragentViewModel()
            {
                PaginationFilter = filter,
                Contragents = _repository.Contragent.GetAll(filter)
            };
            return viewModel;
        }

        public Contragent GetById(int id)
        {
            return _repository.Contragent.GetById(id);
        }

        public void Create(Contragent contragent, string creatorId)
        {
            contragent.Creator = _repository.Users.GetById(creatorId);
            _repository.Contragent.Create(contragent);
            _repository.Save();
        }

        public void Update(Contragent contragent)
        {
            contragent.Creator = _repository.Users.GetById(contragent.Creator.Id);
            _repository.Contragent.Update(contragent);
            _repository.Save();
        }
    }
}
