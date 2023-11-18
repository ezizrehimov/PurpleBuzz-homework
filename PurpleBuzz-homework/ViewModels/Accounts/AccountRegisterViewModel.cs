using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz_homework.ViewModels.Accounts
{
    public class AccountRegisterViewModel
    {

        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password)),Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
