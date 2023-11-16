using EfExtensions.Core.Enum;
using EfExtensions.Core.Interfaces.Model;

namespace Screen.Services.Util;

public static class OperationHelper
{
	public static IEnumerable<T> SetUpdated<T>(this T[] items) where T: class, IHasOperation
	{
		foreach (var item in items)
		{
			item.OperationType = Operation.Updated;
		}
		
		return items;
	}
}