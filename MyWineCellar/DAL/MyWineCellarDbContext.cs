using Microsoft.EntityFrameworkCore;
using MyWineCellar.DAL.Models;

namespace MyWineCellar.DAL
{
	public sealed class MyWineCellarDbContext : DbContext
	{
		public MyWineCellarDbContext()
		{
			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=MyWineCellar.db");

		public DbSet<Wine> Wines { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Wine>().ToTable(nameof(this.Wines));
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