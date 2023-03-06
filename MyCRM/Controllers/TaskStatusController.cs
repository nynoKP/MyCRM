using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Interface.Service;
using MyCRM.Models;

namespace MyCRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TaskStatusController : Controller
    {
        IServiceManager _service;

        public TaskStatusController(IServiceManager service)
        {
            _service = service;
        }



        [Authorize(Roles = "Admin,IndexTaskStatus")]
        public IActionResult Index()
        {
            return View(_service.TaskStatus.GetAll());
        }



        [Authorize(Roles = "Admin,AddTaskStatus")]
        public IActionResult Add(TaskState status)
        {
            _service.TaskStatus.Create(status);
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Admin,EditTaskStatus")]
        public IActionResult Edit(TaskState status)
        {
            _service.TaskStatus.Update(status);
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Admin,DeleteTaskStatus")]
        public IActionResult Delete(int id)
        {
            _service.TaskStatus.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
