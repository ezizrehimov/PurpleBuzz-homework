﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;
using PurpleBuzz_homework.Helpers;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.TeamMember;

namespace PurpleBuzz_homework.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]


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


            teamMember.PhotoName = await fileService.UploadAsync(webHostEnvironment.WebRootPath, teamMember.Photo);
            await appDbContext.AddAsync(teamMember);
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dbModel = await appDbContext.TeamMembers.FindAsync(id);
            if (dbModel == null) return NotFound();

            var model = new TeamMemberUpdateViewModel
            {
                Name = dbModel.Name,
                Position = dbModel.Position,
                PhotoName = dbModel.PhotoName
            };


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, TeamMemberUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dbModel = await appDbContext.TeamMembers.FindAsync(id);
            if (dbModel == null) return NotFound();

            dbModel.Name = model.Name;
            dbModel.Position = model.Position;

            if (model.Photo != null)
            {
                if (!fileService.IsImage(model.Photo))
                {
                    ModelState.AddModelError("Photo", $"{model.Photo.FileName} adli fayl sekil deyil");
                    return View(model);
                }
                else
                {
                    if (!fileService.SizeCheck(model.Photo))
                    {
                        ModelState.AddModelError("Photo", $"{model.Photo.FileName} adli faylin hecmi boyukdur ");
                        return View(model);
                    }
                    fileService.Delete(webHostEnvironment.WebRootPath, dbModel.PhotoName);
                    dbModel.PhotoName = await fileService.UploadAsync(webHostEnvironment.WebRootPath, model.Photo);


                }
            }

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
