using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.ViewModels
{
	public class SignInViewModel
	{
		[Required(ErrorMessage = "required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "required")]
		public string Password { get; set; }
		public bool StaySignedIn { get; set; }
	}
}