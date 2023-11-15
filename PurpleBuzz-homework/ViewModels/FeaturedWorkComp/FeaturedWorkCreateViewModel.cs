﻿using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_homework.ViewModels.FeaturedWorkComp
{
    public class FeaturedWorkCreateViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; } 
    }
}
