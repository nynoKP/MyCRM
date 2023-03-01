using Microsoft.AspNetCore.Identity;
using MyCRM.Interface.Repository;
using MyCRM.Models;

namespace MyCRM.Services
{
    public class UserService
    {
        private readonly IRepositoryManager _repository;
        private readonly UserManager<CRMUser> _userManager;
        public UserService(IRepositoryManager repositoryManager, UserManager<CRMUser> userManager)
        {
            _repository = repositoryManager;
            _userManager = userManager;
        }

        public CRMUser GetById(string id)
        {
            return _repository.Users.GetById(id);
        }

        public void Update(CRMUser user)
        {
            var userFromDb = _userManager.FindByIdAsync(user.Id).Result;
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.Email = user.Email.ToLower();
            userFromDb.UserName = user.Email.ToUpper();
            userFromDb.Patronymic = user.Patronymic;
            userFromDb.PhoneNumber = user.PhoneNumber;
            _userManager.UpdateAsync(userFromDb);
        }
    }
}
