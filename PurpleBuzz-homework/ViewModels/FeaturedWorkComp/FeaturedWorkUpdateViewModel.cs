using PurpleBuzz_homework.Models;

namespace PurpleBuzz_homework.ViewModels.FeaturedWorkComp
{
    public class FeaturedWorkUpdateViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public List<IFormFile>? Photos { get; set; }
        public List<FeaturedWorkPhoto>? FeaturedWorkPhotos { get; set; }
    }
}
