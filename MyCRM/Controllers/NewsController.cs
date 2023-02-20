using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;
using System.Linq;

namespace MyCRM.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<CRMUser> _userManager;

        public NewsController(ApplicationDbContext _context, UserManager<CRMUser> userManager)
        {
            db = _context;
            _userManager = userManager;
        }

        public IActionResult Index(PaginationFilter filter)
        {
            if(!filter.HasValues()) filter = new PaginationFilter(db.News.Count());
            var news = db.News.     OrderByDescending(c => c.CreatedDate).ToQueryString()/*.Where((e, i) => i > (filter.page - 1) * filter.pageSize && i < filter.pageSize * filter.page)*/;
            return View(news);
        }

        public IActionResult FormCreate()
        {
            return View();
        }

        public async Task<IActionResult> Create([FromForm] News news)
        {
            news.CreatedDate = DateTime.Now;
            news.Author = db.CRMUser.Where(c => c.UserName == HttpContext.User.Identity.Name).First();
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
