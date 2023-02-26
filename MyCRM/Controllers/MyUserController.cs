using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Models;
using MyCRM.Repository;

namespace MyCRM.Controllers
{
    [Authorize]
    public class MyUserController : Controller
    {
        private readonly UserManager<CRMUser> _userManager;
        private readonly UserRepository _userRepository;

        public MyUserController(ApplicationDbContext context, UserManager<CRMUser> userManager)
        {
            _userRepository = new UserRepository(context);
            _userManager = userManager;
        }
        public IActionResult Watch(string id)
        {
            return View(_userRepository.GetById(id));
        }
        public IActionResult Edit(string id)
        {
            return View(_userRepository.GetById(id));
        }

        public IActionResult Update([FromForm] CRMUser user)
        {
            var userFromDb = _userManager.FindByIdAsync(user.Id).Result;
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.Email = user.Email.ToLower();
            userFromDb.UserName = user.Email.ToUpper();
            userFromDb.Patronymic = user.Patronymic;
            userFromDb.PhoneNumber = user.PhoneNumber;
            var result = _userManager.UpdateAsync(userFromDb).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Edit", user.Id);
            }
        }
    }
}
