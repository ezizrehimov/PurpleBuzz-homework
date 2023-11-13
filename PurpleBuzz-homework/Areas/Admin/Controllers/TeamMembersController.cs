using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TeamMembersController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TeamMembersController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.appDbContext = appDbContext;
            this.webHostEnvironment = webHostEnvironment;
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

            if (!teamMember.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Yuklenen fayl sekil formatinda olmalidir");
                return View(teamMember);
            }

            if (teamMember.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "Yuklenen sekilin hecmi boyukdur");
                return View(teamMember);
            }

            var fileName = $"{Guid.NewGuid()}_{teamMember.Photo.FileName}";
            var path = Path.Combine(webHostEnvironment.WebRootPath, "assets", "img", fileName);

            using (FileStream fileSteam = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await teamMember.Photo.CopyToAsync(fileSteam);
            }
            teamMember.PhotoName = fileName;
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
            if(model == null) return NotFound();

            var path = Path.Combine(webHostEnvironment.WebRootPath, "assets", "img", model.PhotoName);
            if(System.IO.File.Exists(path)) System.IO.File.Delete(path);
            appDbContext.TeamMembers.Remove(model);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
