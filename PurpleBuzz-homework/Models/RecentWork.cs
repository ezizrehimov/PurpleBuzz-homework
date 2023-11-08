using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_homework.Models
{
    public class RecentWork
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Title yazilmalidir."),MinLength(3,ErrorMessage ="Minimum uzunluq 3 olmalidir.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

    }
}
