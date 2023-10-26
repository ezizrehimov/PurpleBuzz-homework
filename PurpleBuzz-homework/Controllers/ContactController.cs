using Microsoft.AspNetCore.Mvc;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var projectContactInfos = new List<ProjectContactInfo>
            {
                new ProjectContactInfo(1,"Mr ad soyad test1","Media uchun test","055-555-55-55","bx-news"),
                new ProjectContactInfo(2,"Mrs ad soyad test2","Texnikal uchun test","077-777-77-77", "bx-laptop"),
                new ProjectContactInfo(3,"Mr ad soyad test3","Odemeler uchun test","010-100-10-10", "bx-money")
            };

            return View(projectContactInfos);
        }
    }
}
