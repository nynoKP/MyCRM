using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Interface.Service;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace MyCRM.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly IServiceManager _services;

        public NewsController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index(int page = 1)
        {
            var viewModel = _services.News.GetAll(page);
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Watch(int id)
        {
            return View(_services.News.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            return View(_services.News.GetById(id));
        }

        public IActionResult Update(News news)
        {
            _services.News.Update(news);
            return RedirectToAction("Index");
        }

        public IActionResult Create(News news)
        {
            _services.News.Create(news,GetUserId());
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
