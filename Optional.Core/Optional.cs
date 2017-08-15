using System;

namespace Optional.Core
{
	public static class Optional<T>
	{
		private static readonly IOptional<T> EMPTY_VALUE = new EmptyOptional();

		public static IOptional<T> Of(T value) => value == null ? EMPTY_VALUE : new PresentOptional(value);

		public static IOptional<T> Empty() => EMPTY_VALUE;

		private sealed class PresentOptional : IOptional<T>
		{
			public bool IsAbsent => false;
			public T    Value    { get; }

			public PresentOptional(T value) => Value = value;

			public TReturnType Handle<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent) => handlePresent(Value);
			public void        Handle(Action<T> handlePresent, Action handleAbsent)                                    => handlePresent(Value);
			public void        Handle(Action<T> handlePresent)                                                         => handlePresent(Value);
		}

		private sealed class EmptyOptional : IOptional<T>
		{
			public bool IsAbsent => true;
			public T    Value    => throw new ArgumentException("Value is not present.");

			public TReturnType Handle<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent) => handleAbsent();
			public void        Handle(Action<T> handlePresent, Action handleAbsent)                                    => handleAbsent();
			public void        Handle(Action<T> handlePresent)                                                         { }
		}
	}
}