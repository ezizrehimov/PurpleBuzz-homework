using Microsoft.AspNetCore.Mvc;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            var projectWorkValues = new List<ProjectWorkValues>
            {
                new ProjectWorkValues(1,"Digital Marketing test","Digital Marketing description test","/assets/img/our-work-01.jpg"),
                new ProjectWorkValues(2,"Corporate Branding test","Corporate Branding description test","/assets/img/our-work-02.jpg"),
                new ProjectWorkValues(3,"Leading Digital Solution test","Leading Digital Solution description test","/assets/img/our-work-03.jpg"),
                new ProjectWorkValues(4,"Smart Applications test","Smart Applications description test","/assets/img/our-work-04.jpg"),
                new ProjectWorkValues(5,"8 Financial Tips test","8 Financial Tips description test","/assets/img/our-work-06.jpg"),
            };

            return View(projectWorkValues);
        }
    }
}
