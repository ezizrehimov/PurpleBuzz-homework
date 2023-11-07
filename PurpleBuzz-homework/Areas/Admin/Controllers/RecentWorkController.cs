﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dbRecentComp = await appDbContext.projectRecentWorks.FindAsync(id);
            if (dbRecentComp == null) return NotFound();

            return View(dbRecentComp);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProjectRecentWork projectRecentWork)
        {
            if (!ModelState.IsValid) return View(projectRecentWork);

            if (id != projectRecentWork.Id) return BadRequest();

            var dbRecentWork = await appDbContext.projectRecentWorks.FindAsync(id);
            if (dbRecentWork == null) return NotFound();


            bool isExist = await appDbContext.projectRecentWorks
              .AnyAsync(rc => rc.Title.ToLower().Trim() == projectRecentWork.Title.ToLower().Trim() && rc.Id != projectRecentWork.Id);

            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda work movuddur");
                return View(projectRecentWork);
            };

            dbRecentWork.Title = projectRecentWork.Title;
            dbRecentWork.Description = projectRecentWork.Description;
            dbRecentWork.ImagePath = projectRecentWork.ImagePath;

            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dbRecentComp = await appDbContext.projectRecentWorks.FindAsync(id);
            if (dbRecentComp == null) return NotFound();

            return View(dbRecentComp);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var dbRecentComp = await appDbContext.projectRecentWorks.FindAsync(id);
            if (dbRecentComp == null) return NotFound();

            appDbContext.projectRecentWorks.Remove(dbRecentComp);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
