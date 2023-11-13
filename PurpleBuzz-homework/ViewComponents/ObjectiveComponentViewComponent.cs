using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz_homework.DAL;

namespace PurpleBuzz_homework.ViewComponents
{
    public class ObjectiveComponentViewComponent : ViewComponent
    {
        private readonly AppDbContext appDbContext;

        public ObjectiveComponentViewComponent(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await appDbContext.ObjectiveComponents.ToListAsync();
            return View(model);
        }
    }
}
