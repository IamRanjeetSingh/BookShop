using BookShop.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace BookShop.DAL
{
	public class EfDatabaseContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Distributor> Distributors { get; set; }
		public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Cart> Carts { get; set; }

		public EfDatabaseContext() : base(@"Server=DESKTOP-3CET6HL\SQLEXPRESS;Database=BookShop;Trusted_Connection=true;")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDatabaseContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			ConfigureBookEntity(modelBuilder.Entity<Book>());
			ConfigureDistributorEntity(modelBuilder.Entity<Distributor>());
			ConfigureBuyerEntity(modelBuilder.Entity<Buyer>());
			ConfigureCartEntity(modelBuilder.Entity<Cart>());

			base.OnModelCreating(modelBuilder);
		}

		private void ConfigureBookEntity(EntityTypeConfiguration<Book> bookEntity)
		{
			bookEntity.HasKey(b => b.Id);

			bookEntity.Property(b => b.Name).IsRequired();
			bookEntity.Property(b => b.Genre).IsRequired();
			bookEntity.Property(b => b.Language).IsRequired();
			bookEntity.Property(b => b.Price).IsRequired();

			bookEntity
				.HasRequired(b => b.Distributor)
				.WithMany()
				.HasForeignKey(b => b.DistributorId);
		}

		private void ConfigureDistributorEntity(EntityTypeConfiguration<Distributor> distributorEntity)
		{
			distributorEntity.HasKey(d => d.Id);

			distributorEntity.Property(d => d.Name).IsRequired();
			distributorEntity.Property(d => d.Email).IsRequired();
			distributorEntity.Property(d => d.Password).IsRequired();
		}

		private void ConfigureBuyerEntity(EntityTypeConfiguration<Buyer> buyerEntity)
		{
			buyerEntity.HasKey(b => b.Id);

			buyerEntity.Property(b => b.Name).IsRequired();
			buyerEntity.Property(b => b.Email).IsRequired();
			buyerEntity.Property(b => b.Password).IsRequired();
		}

		private void ConfigureCartEntity(EntityTypeConfiguration<Cart> cartEntity)
		{
			cartEntity.HasKey(c => new { c.BuyerId, c.BookId });

			cartEntity
				.HasRequired(c => c.Buyer)
				.WithMany()
				.HasForeignKey(c => c.BuyerId);

			cartEntity
				.HasRequired(c => c.Book)
				.WithMany()
				.HasForeignKey(c => c.BookId);
		}
	}
}