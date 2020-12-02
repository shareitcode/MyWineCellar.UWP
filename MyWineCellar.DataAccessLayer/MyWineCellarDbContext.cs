using Microsoft.EntityFrameworkCore;
using MyWineCellar.DataAccessLayer.Models;

namespace MyWineCellar.DataAccessLayer
{
	public sealed class MyWineCellarDbContext : DbContext
	{
		public DbSet<Wine> Wines { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=MyWineCellar.db");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Wine>().HasKey(wine => wine.Id);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Id).IsUnique();
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Producer);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Country);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Region);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Appellation);
			modelBuilder.Entity<Wine>().HasIndex(wine => wine.Parcel);
		}
	}
}