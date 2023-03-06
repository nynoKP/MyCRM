using Microsoft.AspNetCore.Identity;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class UserService
    {
        private readonly IRepositoryManager _repository;
        private readonly UserManager<CRMUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(IRepositoryManager repositoryManager, UserManager<CRMUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _repository = repositoryManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<CRMUser> GetAll()
        {
            return _repository.Users.GetAll();
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

        public void Create(CRMUser user)
        {
            _userManager.CreateAsync(user).Wait();
        }

        public void EditRoles(IEnumerable<string> roles, string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);
            _userManager.AddToRolesAsync(user, addedRoles).Wait();
            _userManager.RemoveFromRolesAsync(user, removedRoles).Wait();
        }

        public EditUserRolesViewModel GetEditRolesView(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            return new EditUserRolesViewModel
            {
                User = user,
                AllRoles = _roleManager.Roles.ToList(),
                UserRoles = _userManager.GetRolesAsync(user).Result
            };
        }

        public void Delete(string userId)
        {
            _userManager.DeleteAsync(_userManager.FindByIdAsync(userId).Result).Wait();
        }
    }
}
