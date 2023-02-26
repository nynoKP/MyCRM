﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MyCRM.Data;
using MyCRM.Filters;
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
        private readonly ApplicationDbContext context;
        private readonly NewsRepository _newsRepository;
        private readonly UserRepository _userRepository;

        public NewsController(ApplicationDbContext context)
        {
            this.context = context;
            _newsRepository = new NewsRepository(context);
            _userRepository = new UserRepository(context);
        }

        public IActionResult Index(int page = 1)
        {
            var filter = new PaginationFilter(_newsRepository.Count(), page);
            var viewModel = new NewsViewModel()
            {
                PaginationFilter = filter,
                News = _newsRepository.GetAll(filter)
            };
            return View(viewModel);
        }

        public IActionResult FormCreate()
        {
            return View();
        }

        public async Task<IActionResult> Create([FromForm] News news)
        {
            news.CreatedDate = DateTime.Now;
            news.Author = _userRepository.GetById(GetUserId());
            _newsRepository.Add(news);
            _newsRepository.Save();
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
