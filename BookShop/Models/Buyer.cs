using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Buyer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public override bool Equals(object obj)
		{
			if (typeof(Buyer) != obj.GetType())
				return false;

			Buyer b = (Buyer)obj;
			if (
				b.Name == Name &&
				b.Email == Email &&
				b.Password == Password
			)
				return true;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}