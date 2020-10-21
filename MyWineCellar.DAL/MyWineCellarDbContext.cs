using Microsoft.EntityFrameworkCore;
using MyWineCellar.DAL.Models;

namespace MyWineCellar.DAL
{
	public sealed class MyWineCellarDbContext : DbContext
	{
		public MyWineCellarDbContext() => this.Database.Migrate();

		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=MyWineCellar.db");

		public DbSet<Wine> Wines { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Wine>().HasKey(wine => wine.Id);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Id).IsUnique();
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Producer);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Country);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Region);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Appellation);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Parcel);
			modelBuilder.Entity<Wine>(wine =>
			{
				wine.Property(property => property.Producer).IsRequired();
				wine.Property(property => property.Region).IsRequired();
				wine.Property(property => property.Appellation).IsRequired();
				wine.Property(property => property.Parcel).IsRequired();
				wine.Property(property => property.Vintage).HasMaxLength(4).IsRequired();
				wine.Property(property => property.Quantity).IsRequired();
				wine.Property(property => property.Color).IsRequired();
				wine.Property(property => property.AcquisitionDate).IsRequired();
				wine.Property(property => property.AcquisitionMeans).IsRequired();
			});
		}
	}
}