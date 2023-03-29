using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.ViewModels;
using System.Reflection;

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
            userFromDb.NormalizedEmail = user.Email.ToUpper();
            userFromDb.Patronymic = user.Patronymic;
            userFromDb.PhoneNumber = user.PhoneNumber;
            _repository.Users.Update(userFromDb);
            _repository.Save();
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
            var allRoles = _roleManager.Roles.ToList();
            
            var gropedRoles = new List<(string,IEnumerable<IdentityRole>)>();

            Assembly asm = Assembly.GetExecutingAssembly();
            var controllerNames = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .Select(c => c.Name.Replace("Controller", "")).ToList();

            foreach(var controllerName in controllerNames)
            {
                if(allRoles.Where(c => c.Name.EndsWith(controllerName)).Any())
                    gropedRoles.Add((controllerName, allRoles.Where(c=>c.Name.EndsWith(controllerName))));
            }

            var groupedRoeles = gropedRoles.SelectMany(c => c.Item2).ToList();
            var anyRoles = allRoles.Except(groupedRoeles);

            gropedRoles.Add(("Any", anyRoles));

            return new EditUserRolesViewModel
            {
                User = user,
                AllRoles = gropedRoles,
                UserRoles = _userManager.GetRolesAsync(user).Result
            };
        }

        public void Delete(string userId)
        {
            _userManager.DeleteAsync(_userManager.FindByIdAsync(userId).Result).Wait();
        }

        public void Add(RegisterUser userData)
        {
            PasswordHasher<CRMUser> ph = new PasswordHasher<CRMUser>();
            CRMUser user = new CRMUser();
            user.UserName = userData.UserName;
            user.FirstName = userData.FirstName;
            user.LastName = userData.LastName;
            user.Email = userData.Email;
            user.Patronymic = userData.Patronymic;
            user.PhoneNumber = userData.PhoneNumber;
            user.PasswordHash = ph.HashPassword(user, userData.Password);
            _userManager.CreateAsync(user).Wait();
        }
    }
}
