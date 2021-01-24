using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyWineCellar.DAL;
using MyWineCellar.DAL.Models;
using MyWineCellar.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWineCellar.Repository
{
	public static class WineRepository
	{
		private static IMapper Mapper => new Mapper(new MapperConfiguration(configure => configure.AddProfile(new AutoMapperProfile())));

		public static async Task<IEnumerable<WineDto>> GetAll(string path = null)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();
			return Mapper.Map<IEnumerable<WineDto>>(await dbContext.Wines.ToListAsync());
		}

		public static async Task<WineDto> GetById(long wineId)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();

			Wine wineFind = await dbContext.Wines.FindAsync(new { Id = wineId });
			Wine wineSingle = await dbContext.Wines.SingleOrDefaultAsync(wine => wine.Id.Equals(wineId));

			return Mapper.Map<WineDto>(wineFind);
		}

		public static async Task Add(WineDto wineToAdd)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();
			await using IDbContextTransaction transaction = await dbContext.Database.BeginTransactionAsync();

			Wine wineAdded = (await dbContext.Wines.AddAsync(Mapper.Map<Wine>(wineToAdd))).Entity;
			await dbContext.SaveChangesAsync();

			if (wineAdded.Id > 0)
				await transaction.CommitAsync();
		}

		public static async Task Update(WineDto wineToUpdate)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();
			await using IDbContextTransaction transaction = await dbContext.Database.BeginTransactionAsync();

			Wine wineUpdated = dbContext.Wines.Update(Mapper.Map<Wine>(wineToUpdate)).Entity;
			await dbContext.SaveChangesAsync();

			if (wineToUpdate.Id.Equals(wineUpdated.Id))
				await transaction.CommitAsync();
		}

		public static async Task Delete(WineDto wineToDelete)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();
			await using IDbContextTransaction transaction = await dbContext.Database.BeginTransactionAsync();

			Wine wineDeleted = dbContext.Wines.Remove(Mapper.Map<Wine>(wineToDelete)).Entity;
			await dbContext.SaveChangesAsync();

			if (wineToDelete.Id.Equals(wineDeleted.Id))
				await transaction.CommitAsync();
		}
	}
}