using System;
using System.Collections.Generic;
using System.Linq;

namespace Optional.Core
{
	public static class EnumerableExtension
	{
		public static IOptional<T> SingleOrOptional<T>(this IEnumerable<T> items) =>
			Optional<T>.Of(items.SingleOrDefault());

		public static IOptional<T> SingleOrOptional<T>(this IEnumerable<T> items, Func<T, bool> match) =>
			Optional<T>.Of(items.SingleOrDefault(match));

		public static IOptional<T> FirstOrOptional<T>(this IEnumerable<T> items) =>
			Optional<T>.Of(items.FirstOrDefault());

		public static IOptional<T> FirstOrOptional<T>(this IEnumerable<T> items, Func<T, bool> match) =>
			Optional<T>.Of(items.FirstOrDefault(match));
	}
}