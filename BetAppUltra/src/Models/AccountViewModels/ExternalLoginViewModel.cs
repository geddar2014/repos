using System.ComponentModel.DataAnnotations;

namespace BetAppUltra.Models.AccountViewModels
{
	public class ExternalLoginViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}