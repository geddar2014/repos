using System.ComponentModel.DataAnnotations;

namespace BetAppUltra.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
