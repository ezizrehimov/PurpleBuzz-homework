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


            //var categories = await appDbContext.ProjectWorkCategories.
            //    Include(x => x.WorkValues).
            //    ToListAsync();

            //var categoriesValues = await appDbContext.ProjectWorkValues.ToListAsync();


            //var model = new WorkIndexVM
            //{
            //    ProjectWorkCategories = categories,
            //    ProjectWorkValues = categoriesValues
            //};

            // model
            return View();
        }
    }
}
