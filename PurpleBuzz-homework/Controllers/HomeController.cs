using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.Home;

namespace PurpleBuzz_homework.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {

            var services = await appDbContext.Services.ToListAsync();

            var recentWorks = await appDbContext.RecentWorks.OrderByDescending(rw => rw.Id)
                .Skip(3)
                .Take(3)
                .ToListAsync();



            var model = new HomeVM()
            {
                Services = services,
                RecentWork = recentWorks
            };

            return View(model);
        }


        public async Task<IActionResult> loadmore(int skipRow)
        {
            var recentWorks = await appDbContext.RecentWorks.OrderByDescending(rw => rw.Id)
                .Skip(3 * skipRow)
                .Take(3)
                .ToListAsync();

            return PartialView("_RecentWorkPartialView", recentWorks);
        }


    }
}
