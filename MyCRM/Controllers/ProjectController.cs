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
    public class ProjectController : Controller
    {
        private readonly IServiceManager _service;

        public ProjectController(IServiceManager service)
        {
            _service = service;
        }
        public IActionResult Index(int page = 1)
        {
            var viewModel = _service.Project.GetIndexView(page);
            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = _service.Project.GetAddView();
            return View(viewModel);
        }

        public IActionResult Watch(int id)
        {
            return View(_service.Project.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            var viewModel = _service.Project.GetEditView(id);
            return View(viewModel);
        }

        public IActionResult Update(Project project)
        {
            _service.Project.Update(project);
            return RedirectToAction("Index");
        }

        public IActionResult Create(Project project)
        {
            _service.Project.Create(project, GetUserId());
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
