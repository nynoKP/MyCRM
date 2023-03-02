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
    public class TasksController : Controller
    {
        private readonly IServiceManager _service;

        public TasksController(IServiceManager service)
        {
            _service = service;
        }

        public IActionResult Index(TaskFilter? taskFilter)
        {
            var viewModel = _service.Task.GetIndexView(taskFilter);
            return View(viewModel);
        }

        public IActionResult Create(Tasks task)
        {
            _service.Task.Create(task, GetUserId());
            return RedirectToAction("Index");
        }

        public IActionResult Watch(int id)
        {
            return View(_service.Task.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            var viewModel = _service.Task.GetEditViewModel(id);
            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = _service.Task.GetAddView();
            return View(viewModel);
        }

        public IActionResult Update(Tasks task)
        {
            _service.Task.Update(task);
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
