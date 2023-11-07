using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorkController : Controller
    {
        private readonly AppDbContext appDbContext;

        public RecentWorkController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<IActionResult> Index()
        {

            var model = await appDbContext.projectRecentWorks.ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRecentWork projectRecentWork)
        {

            if (!ModelState.IsValid) return View(projectRecentWork);

            bool isExist = await appDbContext.projectRecentWorks.AnyAsync(rc => rc.Title == projectRecentWork.Title);

            if (isExist)
            {
                ModelState.AddModelError("Title", "BU adda work movuddur");
                return View(projectRecentWork);
            }
            await appDbContext.projectRecentWorks.AddAsync(projectRecentWork);
            await appDbContext.SaveChangesAsync();  

            return RedirectToAction("Index");
        }
    }
}
