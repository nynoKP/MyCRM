using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;
using System.Security.Claims;

namespace MyCRM.Controllers
{
    public class ContragentController : Controller
    {
        
        private readonly ApplicationDbContext context;
        private readonly ContragentRepository contragentRepository;
        private readonly UserRepository userRepository;

        public ContragentController(ApplicationDbContext context)
        {
            this.context = context;
            contragentRepository = new ContragentRepository(context);
            userRepository = new UserRepository(context);
        }
        public IActionResult Index(int page = 1)
        {
            var filter = new PaginationFilter(contragentRepository.Count(),page);
            var viewModel = new ContragentViewModel()
            {
                PaginationFilter = filter,
                Contragents = contragentRepository.GetAll(filter)
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Watch(int id)
        {
            return View(contragentRepository.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            var contragent = contragentRepository.GetById(id);
            return View(contragent);
        }

        public IActionResult Update(Contragent contragent)
        {
            contragent.Creator = contragentRepository.GetById(contragent.Id).Creator;
            contragentRepository.Update(contragent);
            contragentRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Create([FromForm] Contragent contragent)
        {
            contragent.Creator = userRepository.GetById(GetUserId());
            contragentRepository.Add(contragent);
            contragentRepository.Save();
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
