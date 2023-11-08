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

            var projectComponents = await appDbContext.ProjectComponents.ToListAsync();

            var projectRecentWorks = await appDbContext.RecentWorks.ToListAsync();


            var model = new HomeVM()
            {
                projectComponents = projectComponents,
                projectRecentWorks = projectRecentWorks
            };

            return View(model);
        }
    }
}
