using Microsoft.EntityFrameworkCore;
using MyWineCellar.DAL;
using MyWineCellar.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using MyWineCellar.DAL.Models;

namespace MyWineCellar.Repository
{
	public static class WineRepository
	{
		public static async Task<IEnumerable<WineDto>> GetAllWines(string path)
		{
			await using MyWineCellarDbContext dbContext = new MyWineCellarDbContext();
			List<Wine> wines = await dbContext.Wines.ToListAsync();

			using (SqliteConnection sqliteConnection = new SqliteConnection("FileName=" + path))
			{
				await sqliteConnection.GetAllAsync<Wine>();
			}

			return Enumerable.Empty<WineDto>();
			//using SqliteConnection sqliteConnection = new SqliteConnection("Filename=MyWineCellar.db");
			//return await sqliteConnection.QueryAsync<WineDto>("SELECT * FROM WINES");
		}
	}
}