using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModel
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
