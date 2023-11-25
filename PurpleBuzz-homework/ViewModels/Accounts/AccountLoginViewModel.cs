using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_homework.ViewModels.Accounts
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
