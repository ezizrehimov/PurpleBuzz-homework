using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.Work;

namespace PurpleBuzz_homework.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]


    public class WorkController : Controller
    {
        private readonly AppDbContext appDbContext;

        public WorkController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<IActionResult> Index()
        {
            var model = await appDbContext.WorkValues.ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await appDbContext.WorkCategories.ToListAsync();
            var selectedList = new List<SelectListItem>();
            foreach (var category in categories)
            {
                selectedList.Add(new SelectListItem
                {
                    Text = category.Title,
                    Value = category.Id.ToString()
                });
            }

            var model = new WorkCreateVM
            {
                Items = selectedList
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateVM workValues)
        {
            var values = new WorkValues();

            values.Title = workValues.Title;
            values.Description = workValues.Description;
            values.ImagePath = workValues.ImagePath;

            foreach (var item in workValues.workCategoryIds)
            {
                if (await appDbContext.WorkCategories.FindAsync(item) != null)
                {
                    values.CategoryValues.Add(new WorkCategoryValues
                    {
                        workCategoriesId = item,
                        workValuesId = values.Id
                    });
                }


            }

            await appDbContext.WorkValues.AddAsync(values);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
