using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.Work;

namespace PurpleBuzz_homework.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext appDbContext;

        public WorkController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {


            var categories = await appDbContext.WorkCategories.
                Include(x => x.CategoryValues).
                ThenInclude(cv => cv.workValues).
                ToListAsync();



            var model = new WorkIndexVM
            {
                WorkCategories = categories,
            };

            return View(model);
        }
    }
}
