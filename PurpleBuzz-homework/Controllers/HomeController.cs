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
                new ProjectComponents(1,"UI/UX test","UI/UX description test","/assets/img/services-01.jpg"),
                new ProjectComponents(2,"Social Media test","Social Media description test","/assets/img/services-02.jpg"),
                new ProjectComponents(3,"Marketing test","Marketing description test","/assets/img/services-03.jpg"),
                new ProjectComponents(4,"Graphic test","Graphic description test","/assets/img/services-04.jpg"),
            };

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
