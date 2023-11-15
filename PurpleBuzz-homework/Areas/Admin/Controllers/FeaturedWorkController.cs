using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Helpers;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.FeaturedWorkComp;

namespace PurpleBuzz_homework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedWorkController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IFileService fileService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FeaturedWorkController(AppDbContext appDbContext, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            this.appDbContext = appDbContext;
            this.fileService = fileService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var model = await appDbContext.FeaturedWorks.FirstOrDefaultAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await appDbContext.FeaturedWorks.FirstOrDefaultAsync();
            if (model != null) return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeaturedWorkCreateViewModel model)
        {
            var dbModel = await appDbContext.FeaturedWorks.FirstOrDefaultAsync();
            if (dbModel != null) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            var featuredWork = new FeaturedWork
            {
                Name = model.Name,
                Description = model.Description,
                Title = model.Title
            };

            bool hasError = false;
            foreach (var item in model.Photos)
            {
                if (!fileService.IsImage(item))
                {
                    ModelState.AddModelError("Photos", $"{item.FileName} adli fayl sekil deyil");
                    hasError = true;
                }
                else
                {
                    if (!fileService.SizeCheck(item))
                    {
                        ModelState.AddModelError("Photos", $"{item.FileName} adli faylin hecmi boyukdur ");
                        hasError = true;
                    }
                }
            }
            if (hasError) return View(model);
    
            await appDbContext.FeaturedWorks.AddAsync(featuredWork);
            await appDbContext.SaveChangesAsync();

            foreach (var item in model.Photos)
            {
                var featuredworkPhoto = new FeaturedWorkPhoto
                {
                    Name = await fileService.UploadAsync(webHostEnvironment.WebRootPath, item)
                };
                featuredworkPhoto.FeaturedWorkId = featuredWork.Id;
                await appDbContext.FeaturedWorkPhotos.AddAsync(featuredworkPhoto);
                await appDbContext.SaveChangesAsync();


            }

            return RedirectToAction("Index");
        }

    }
}
