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

            var projectCategories = new List<ProjectCategories>
            {
                new ProjectCategories(1,"Social Media test","Social Media description test",""),
                new ProjectCategories(2,"Web marketing test","Web marketing description test",""),
                                new ProjectCategories(3,"R & D test","R & D description test",""),
                new ProjectCategories(4,"Branding test","Branding description test",""),
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
