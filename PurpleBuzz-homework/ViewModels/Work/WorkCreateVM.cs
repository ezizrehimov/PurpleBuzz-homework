using Microsoft.AspNetCore.Mvc.Rendering;

namespace PurpleBuzz_homework.ViewModels.Work
{
    public class WorkCreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public List<SelectListItem> Items { get; set; }

        public List<int> workCategoryIds { get; set; }

    }
}
