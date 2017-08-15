using System;
using Moq;

namespace Optional.Core.Mocks
{
	public class MockOptional<T> : IOptional<T>
	{
		private readonly Mock<IOptional<T>> _mock = new Mock<IOptional<T>>();
		public           bool               IsAbsent                                                                                => _mock.Object.IsAbsent;
		public           T                  Value                                                                                   => _mock.Object.Value;
		public           TReturnType        Handle<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent) => _mock.Object.Handle(handlePresent, handleAbsent);
		public           void               Handle(Action<T> handlePresent, Action handleAbsent)                                    => _mock.Object.Handle(handlePresent, handleAbsent);
		public           void               Handle(Action<T> handlePresent)                                                         => _mock.Object.Handle(handlePresent);

		public MockOptional<T> HandleReturns<TReturnType>(TReturnType handle)
		{
			_mock.Setup(m => m.Handle(It.IsAny<Func<T, TReturnType>>(), It.IsAny<Func<TReturnType>>())).Returns(handle);
			return this;
		}

		public MockOptional<T> IsAbsentReturns(bool isAbsent)
		{
			_mock.Setup(m => m.IsAbsent).Returns(isAbsent);
			return this;
		}

		public MockOptional<T> ValueReturns(T value)
		{
			_mock.Setup(m => m.Value).Returns(value);
			return this;
		}

		public void VerifyHandleCalled<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent, int times = 1) { _mock.Verify(m => m.Handle(handlePresent, handleAbsent), Times.Exactly(times)); }

		public void VerifyHandleCalled<TReturnType>(Action<T> handlePresent, Action handleAbsent, int times = 1) { _mock.Verify(m => m.Handle(handlePresent, handleAbsent), Times.Exactly(times)); }

		public void VerifyHandleCalled<TReturnType>(Action<T> handlePresent, int times = 1) { _mock.Verify(m => m.Handle(handlePresent), Times.Exactly(times)); }

		public void VerifyIsAbsentCalled(int times = 1) { _mock.Verify(m => m.IsAbsent, Times.Exactly(times)); }

		public void VerifyValueCalled(int times = 1) { _mock.Verify(m => m.Value, Times.Exactly(times)); }
	}
}