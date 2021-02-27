using System;

namespace BookShop.Models
{
	public class Distributor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public override bool Equals(object obj)
		{
			if (typeof(Distributor) != obj.GetType())
				return false;

			Distributor d = (Distributor)obj;
			if (
				d.Name == Name &&
				d.Email == Email &&
				d.Password == Password
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