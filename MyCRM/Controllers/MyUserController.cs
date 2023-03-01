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
    public class MyUserController : Controller
    {
        private readonly IServiceManager _service;
        public MyUserController(IServiceManager service)
        {
            _service = service;
        }
        public IActionResult Watch(string id)
        {
            return View(_service.User.GetById(id));
        }
        public IActionResult Edit(string id)
        {
            return View(_service.User.GetById(id));
        }

        public IActionResult Update(CRMUser user)
        {
            _service.User.Update(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
