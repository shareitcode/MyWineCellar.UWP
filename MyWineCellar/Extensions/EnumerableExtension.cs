using System.Collections.Generic;
using System.Linq;

namespace MyWineCellar.Extensions
{
	internal static class EnumerableExtension
	{
		internal static bool IsNotNullOrNotEmpty<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();
	}
}