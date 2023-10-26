using Microsoft.AspNetCore.Mvc;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var projectTeamMembers = new List<ProjectTeamMembers>
            {
                new ProjectTeamMembers(1,"Birinci shexs test","Business Dev description test","/assets/img/team-01.jpg"),
                new ProjectTeamMembers(2,"Birinci shexs test","Marketing Dev description test","/assets/img/team-02.jpg"),
                new ProjectTeamMembers(3,"Birinci shexs test","Simple Dev description test","/assets/img/team-03.jpg")
            };

            return View(projectTeamMembers);
        }
    }
}
