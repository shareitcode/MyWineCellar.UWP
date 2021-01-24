using AutoMapper;

namespace MyWineCellar.Helpers
{
	internal sealed class MapModels
	{
		private static IMapper Mapper => new Mapper(new MapperConfiguration(configure => configure.AddProfile(new AutoMapperProfile())));

		public static T Map<T>(object objectToMap)
		{
			return Mapper.Map<T>(objectToMap);
		}
	}
}