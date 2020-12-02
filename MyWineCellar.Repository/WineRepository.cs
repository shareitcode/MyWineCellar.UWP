using Microsoft.EntityFrameworkCore;
using MyWineCellar.DAL;
using MyWineCellar.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using MyWineCellar.DAL.Models;

namespace MyWineCellar.Repository
{
	public static class WineRepository
	{
		private static IMapper Mapper => new Mapper(new MapperConfiguration(configure => configure.AddProfile(new AutoMapperProfile())));

		public static async Task<IEnumerable<WineDto>> GetAllWines(string path = null)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();
			return Mapper.Map<IEnumerable<WineDto>>(await dbContext.Wines.ToListAsync());

			//using (SqliteConnection sqliteConnection = new SqliteConnection("FileName=" + path))
			//{
			//	return _mapper.Map<IEnumerable<WineDto>>(await sqliteConnection.GetAllAsync<Wine>());
			//}
		}
	}
}