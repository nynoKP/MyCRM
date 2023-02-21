using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;
using System.Linq;
using System.Security.Claims;

namespace MyCRM.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index(PaginationFilter filter)
        {
            
            if(!filter.HasValues()) filter = new PaginationFilter(_context.News.Count());
            List<(string, CRMNews)> values = new List<(string, CRMNews)>();
            var news = _context.News.Include(v => v.Author).OrderByDescending(c => c.CreatedDate).ToList().Where((e, i) => i >= (filter.page - 1) * filter.pageSize && i < filter.pageSize * filter.page).ToList();
            return View(news);
        }

        public IActionResult FormCreate()
        {
            return View();
        }

        public async Task<IActionResult> Create([FromForm] CRMNews news)
        {
            news.CreatedDate = DateTime.Now;
            news.Author = _context.Users.Where(c=>c.Id == GetUserId()).First();
            _context.News.Add(news);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
