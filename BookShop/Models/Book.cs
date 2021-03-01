using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int DistributorId { get; set; }
		public Distributor Distributor { get; set; }
		public double Price { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
		public string Publisher { get; set; }
		public string Language { get; set; }
		public DateTime AddedAt { get; set; }

		public override bool Equals(object obj)
		{
			if (typeof(Book) != obj.GetType())
				return false;
			Book b = (Book)obj;
			if (
				b.Name == Name &&
				b.Description == Description &&
				b.DistributorId == DistributorId &&
				b.Price == Price &&
				b.Author == Author &&
				b.Genre == Genre &&
				b.Publisher == Publisher &&
				b.Language == Language &&
				b.AddedAt == AddedAt
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