using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.About;

namespace PurpleBuzz_homework.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var teamMembers = new List<TeamMembers>
            {
                new TeamMembers(1,"Birinci shexs test","Business Dev description test","/assets/img/team-01.jpg"),
                new TeamMembers(2,"Birinci shexs test","Marketing Dev description test","/assets/img/team-02.jpg"),
                new TeamMembers(3,"Birinci shexs test","Simple Dev description test","/assets/img/team-03.jpg")
            };

            var objectiveComponent = await appDbContext.ObjectiveComponents.ToListAsync();

            var model = new AboutVM
            {
                TeamMembers = teamMembers,
                ObjectiveComponent = objectiveComponent
            };

            return View(model);
        }
    }
}
