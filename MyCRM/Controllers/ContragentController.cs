using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Interface.Service;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;
using System.Security.Claims;

namespace MyCRM.Controllers
{
    [Authorize]
    public class ContragentController : Controller
    {
        private readonly IServiceManager _services;

        public ContragentController(IServiceManager service)
        {
            _services = service;
        }
        public IActionResult Index(int page = 1)
        {
            var viewModel = _services.Contragent.GetAll(page);
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Watch(int id)
        {
            return View(_services.Contragent.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            return View(_services.Contragent.GetById(id));
        }

        public IActionResult Update(Contragent contragent)
        {
            _services.Contragent.Update(contragent);
            return RedirectToAction("Index");
        }

        public IActionResult Create(Contragent contragent)
        {
            _services.Contragent.Create(contragent, GetUserId());
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
