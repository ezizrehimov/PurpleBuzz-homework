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

            var projectCategories = new List<ProjectCategories>
            {
                new ProjectCategories(1,"Social Media test","Social Media description test","/assets/img/recent-work-01.jpg"),
                new ProjectCategories(2,"Web marketing test","Web marketing description test","/assets/img/recent-work-02.jpg"),
                new ProjectCategories(3,"R & D test","R & D description test","/assets/img/recent-work-03.jpg"),
                new ProjectCategories(4,"Branding test","Branding description test","/assets/img/recent-work-05.jpg"),
            };


            var model = new HomeVM()
            {
                projectComponents = projectComponents,
                projectCategories = projectCategories
            };

            return View(model);
        }
    }
}
