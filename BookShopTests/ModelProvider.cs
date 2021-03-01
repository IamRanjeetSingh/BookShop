using BookShop.DAL;
using BookShop.Models;
using System;
using System.Linq;

namespace BookShopTests
{
	public class ModelProvider
	{
		public static Book GetValidBook(bool alreadyInsertedInDb)
		{
			Book book;
			if (alreadyInsertedInDb)
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					book = db.Books.FirstOrDefault();
					if (book == null)
					{
						book = CreateBook();
						db.Books.Add(book);
						db.SaveChanges();
					}
				}
			}
			else
			{
				Distributor distributor = GetValidDistributor(alreadyInsertedInDb: true);
				book = CreateBook();
			}

			return book;
		}

		private static Book CreateBook()
		{
			return new Book()
			{
				Name = "test",
				Description = "test",
				Author = "test",
				Publisher = "test",
				Genre = "test",
				Language = "test",
				Price = 1000,
				DistributorId = GetValidDistributor(alreadyInsertedInDb: true).Id
			};
		}

		public static Book[] GetInvalidBooks()
		{
			return new Book[]{
				null,
				new Book(),
				new Book() { Name = "Test" },
				new Book() { Name = "Test", Description = "Test description" },
				new Book() { Name = "Test", Description = "description", Author = "author" },
				new Book() { Name = "Test", Description = "Test description", Author = "author", Publisher = "publisher" },
				new Book() { Name = "Test", Description = "Test description", Author = "author", Publisher = "publisher", Genre = "genre" },
				new Book() { Name = "Test", Description = "Test description", Author = "author", Publisher = "publisher", Genre = "genre", Language = "language" },
			};
		}

		public static Distributor GetValidDistributor(bool alreadyInsertedInDb)
		{
			Distributor distributor;
			if (alreadyInsertedInDb)
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					distributor = db.Distributors.FirstOrDefault();
					if (distributor == null)
					{
						distributor = CreateDistributor();

						db.Distributors.Add(distributor);
						db.SaveChanges();
					}
				}
			}
			else
			{
				distributor = CreateDistributor();
			}

			return distributor;
		}

		private static Distributor CreateDistributor()
		{
			return new Distributor()
			{
				Name = "test",
				Email = "test",
				Password = "test"
			};

		}

		public static Distributor[] GetInvalidDistributors()
		{
			return new Distributor[]
			{
				null,
				new Distributor(),
				new Distributor(){ Name = "Test" },
				new Distributor(){ Name = "Test", Email = "test@email.com_"+DateTime.Now },
			};
		}

		public static Buyer GetValidBuyer(bool alreadyInsertedInDb)
		{
			Buyer buyer;
			if (alreadyInsertedInDb)
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					buyer = db.Buyers.FirstOrDefault();
					if (buyer == null)
					{
						buyer = CreateBuyer();

						db.Buyers.Add(buyer);
						db.SaveChanges();
					}
				}
			}
			else
			{
				buyer = CreateBuyer();
			}

			return buyer;
		}

		private static Buyer CreateBuyer()
		{
			return new Buyer()
			{
				Name = "test",
				Email = "test",
				Password = "test"
			};
		}

		public static Buyer[] GetInvalidBuyers()
		{
			return new Buyer[]
			{
				null,
				new Buyer(),
				new Buyer(){ Name = "Test" },
				new Buyer(){ Name = "Test", Email = "test@email.com_"+DateTime.Now },
			};
		}

		public static Cart GetValidCart(bool alreadyInsertedInDb)
		{
			Cart cart;
			if(alreadyInsertedInDb)
			{
				using(EfDatabaseContext db = new EfDatabaseContext())
				{
					cart = db.Carts.FirstOrDefault();
					if(cart == null)
					{
						cart = CreateCart();

						db.Carts.Add(cart);
						db.SaveChanges();
					}
				}
			}
			else
			{
				cart = CreateCart();
			}

			return cart;
		}

		private static Cart CreateCart()
		{
			return new Cart()
			{
				BuyerId = GetValidBuyer(alreadyInsertedInDb: true).Id,
				BookId = GetValidBook(alreadyInsertedInDb: true).Id
			};

		}

		public static Cart[] GetInvalidCarts()
		{
			return new Cart[]
			{
				null,
				new Cart()
			};
		}
	}
}
