using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.About;

namespace PurpleBuzz_homework.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly AppDbContext appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
           


            var model = new AboutVM
            {
            };

            return View(model);
        }
    }
}
