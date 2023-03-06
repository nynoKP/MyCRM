using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Interface.Service;
using MyCRM.Models;
using MyCRM.Repository;

namespace MyCRM.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin,WatchUser")]
        public IActionResult Watch(string id)
        {
            return View(_service.User.GetById(id));
        }

        [Authorize(Roles = "Admin,EditUser")]
        public IActionResult Edit(string id)
        {
            return View(_service.User.GetById(id));
        }

        [Authorize(Roles = "Admin,IndexUser")]
        public IActionResult Index()
        {
            return View(_service.User.GetAll());
        }

        [Authorize(Roles = "Admin,UpdateUser")]
        public IActionResult Update(CRMUser user)
        {
            _service.User.Update(user);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin,CreateUser")]
        public IActionResult Create(CRMUser user)
        {
            PasswordHasher<CRMUser> ph = new PasswordHasher<CRMUser>();
            user.PasswordHash = ph.HashPassword(user, user.PasswordHash);
            user.NormalizedUserName = user.UserName.ToUpper();
            user.NormalizedEmail = user.Email.ToUpper();
            _service.User.Create(user);
            return RedirectToAction("Index", "User");
        }

        [Authorize(Roles = "Admin,EditRolesUser")]
        [HttpPost]
        public IActionResult EditRoles(IEnumerable<string> roles, string userId)
        {
            _service.User.EditRoles(roles, userId);
            return RedirectToAction("Index", "User");
        }

        [Authorize(Roles = "Admin,EditRolesUser")]
        public IActionResult EditRoles(string userId)
        {
           var viewModel = _service.User.GetEditRolesView(userId);
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,DeleteUser")]
        public IActionResult Delete(string userId)
        {
            _service.User.Delete(userId);
            return RedirectToAction("Index", "User");
        }
    }
}
