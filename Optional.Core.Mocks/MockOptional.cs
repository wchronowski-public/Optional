using System;
using Moq;

namespace Optional.Core.Mocks {
    public class MockOptional<T> : IOptional<T> {
        public bool IsAbsent => _mock.Object.IsAbsent;
        public T Value => _mock.Object.Value;
        private readonly Mock<IOptional<T>> _mock = new Mock<IOptional<T>>();
        public TReturnType Handle<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent) => _mock.Object.Handle(handlePresent, handleAbsent);

        public MockOptional<T> IsAbsentReturns(bool isAbsent) {
            _mock.Setup(m => m.IsAbsent).Returns(isAbsent);
            return this;
        }

        public MockOptional<T> ValueReturns(T value) {
            _mock.Setup(m => m.Value).Returns(value);
            return this;
        }

        public MockOptional<T> HandleReturns<TReturnType>(TReturnType handle) {
            _mock.Setup(m => m.Handle(It.IsAny<Func<T, TReturnType>>(), It.IsAny<Func<TReturnType>>())).Returns(handle);
            return this;
        }

        public void VerifyIsAbsentCalled(int times = 1) {
            _mock.Verify(m => m.IsAbsent, Times.Exactly(times));
        }

        public void VerifyValueCalled(int times = 1) {
            _mock.Verify(m => m.Value, Times.Exactly(times));
        }

        public void VerifyHandleCalled<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent, int times = 1) {
            _mock.Verify(m => m.Handle(handlePresent, handleAbsent), Times.Exactly(times));
        }
    }
}