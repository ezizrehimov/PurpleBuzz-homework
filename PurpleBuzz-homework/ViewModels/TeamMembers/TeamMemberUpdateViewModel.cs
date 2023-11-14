using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_homework.ViewModels.TeamMember
{
    public class TeamMemberUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }

        public string? PhotoName { get; set; }
    
        public IFormFile? Photo { get; set; }
    }
}
