using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzz_homework.Models;
using PurpleBuzz_homework.ViewModels.Accounts;

namespace PurpleBuzz_homework.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid) return View(model);

            User user = new User
            {
                fullName = model.Fullname,
                Email = model.Email,
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            return RedirectToAction("login");
        }

    }
}
