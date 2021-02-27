using System.ComponentModel.DataAnnotations;

namespace BookShop.ViewModels
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage = "required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "required")]
		[RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$", ErrorMessage = "must have a valid format eg. john@gmail.com")]
		public string Email { get; set; }
		[Required(ErrorMessage = "required")]
		public string Password { get; set; }
		[Required(ErrorMessage = "required")]
		[Compare("Password", ErrorMessage = "Must match with password")]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
	}
}