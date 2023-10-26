using Microsoft.AspNetCore.Mvc;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.Home;

namespace PurpleBuzz_homework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var projectComponents = new List<ProjectComponents>
            {
                new ProjectComponents(1,"UI/UX test","UI/UX description test",""),
                new ProjectComponents(2,"Social Media test","Social Media description test",""),
                new ProjectComponents(3,"Marketing test","Marketing description test",""),
                new ProjectComponents(4,"Graphic test","Graphic description test",""),
            };

            var model = new HomeVM()
            {
                projectComponents = projectComponents
            };
             
            return View(model);
        }
    }
}
