using Microsoft.AspNetCore.Identity;

namespace PurpleBuzz_homework.Models
{
    public class User : IdentityUser
    {
        public string fullName { get; set; }
    }
}
