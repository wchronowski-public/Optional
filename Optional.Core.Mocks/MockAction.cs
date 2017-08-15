using Xunit;

namespace Optional.Core.Mocks
{
	public class MockAction
	{
		private int _calledCount;

		public void Run() => _calledCount++;

		public void VerifyActionCalled(int times = 1) =>
			Assert.Equal(1, _calledCount);

		public void VerifyActionNotCalled() =>
			Assert.Equal(0, _calledCount);
	}

	public class MockAction<TParam>
	{
		private int    _calledCount;
		private TParam _param;

		public void Run(TParam param)
		{
			_param = param;
			_calledCount++;
		}

		public void VerifyActionCalled(TParam param, int times = 1)
		{
			Assert.Equal(_param, param);
			Assert.Equal(1, _calledCount);
		}

		public void VerifyActionNotCalled() => Assert.Equal(0, _calledCount);
	}
}