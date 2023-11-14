using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Helpers;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TeamMembersController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IFileService fileService;

        public TeamMembersController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            this.appDbContext = appDbContext;
            this.webHostEnvironment = webHostEnvironment;
            this.fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await appDbContext.TeamMembers.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamMembers teamMember)
        {

            if (!ModelState.IsValid) return View(teamMember);

            if (!fileService.IsImage(teamMember.Photo))
            {
                ModelState.AddModelError("Photo", "Yuklenen fayl sekil formatinda olmalidir");
                return View(teamMember);
            }

            if (!fileService.SizeCheck(teamMember.Photo))
            {
                ModelState.AddModelError("Photo", "Yuklenen sekilin hecmi boyukdur");
                return View(teamMember);
            }


            teamMember.PhotoName = await fileService.UploadSync(webHostEnvironment.WebRootPath, teamMember.Photo);
            await appDbContext.AddAsync(teamMember);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await appDbContext.TeamMembers.FindAsync(id);
            if (model == null) return NotFound();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var model = await appDbContext.TeamMembers.FindAsync(id);
            if (model == null) return NotFound();

             fileService.Delete(webHostEnvironment.WebRootPath, model.PhotoName);
            appDbContext.TeamMembers.Remove(model);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
