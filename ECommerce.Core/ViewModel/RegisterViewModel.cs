using System.ComponentModel.DataAnnotations;
namespace ECommerce.ViewModel
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "*")]
        [MaxLength(50)]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public string PhoneNumber { get; set; }
    }
}
