using Xunit;

namespace Optional.Core.Mocks
{
	public class MockFunction<TResult>
	{
		private int     _calledCount;
		private TResult _result;

		public TResult Run()
		{
			_calledCount++;
			return _result;
		}

		public MockFunction<TResult> RunReturns(TResult result)
		{
			_result = result;
			return this;
		}

		public void VerifyFunctionCalled(int times = 1) =>
			Assert.Equal(1, _calledCount);

		public void VerifyFunctionNotCalled() =>
			Assert.Equal(0, _calledCount);
	}

	public class MockFunction<TResult, TParam>
	{
		private int     _calledCount;
		private TParam  _param;
		private TResult _result;

		public TResult Run(TParam param)
		{
			_param = param;
			_calledCount++;
			return _result;
		}

		public MockFunction<TResult, TParam> RunReturns(TResult result)
		{
			_result = result;
			return this;
		}

		public void VerifyFunctionCalled(TParam param, int times = 1)
		{
			Assert.Equal(_param, param);
			Assert.Equal(1, _calledCount);
		}

		public void VerifyFunctionNotCalled() =>
			Assert.Equal(0, _calledCount);
	}
}