using System;
using Optional.Core.Mocks;
using Xunit;

namespace Optional.Core.Tests
{
	public class OptionalTest
	{
		[Fact]
		public void Handle_WhenEmpty_ReturnAbsentFunctionValue()
		{
			var handlePresent = new MockFunction<string>().RunReturns("present");
			var handleAbsent = new MockFunction<string>().RunReturns("absent");
			var option = Optional<string>.Empty();

			var result = option.Handle(value => handlePresent.Run(), () => handleAbsent.Run());

			Assert.Equal("absent", result);
			handlePresent.VerifyFunctionNotCalled();
			handleAbsent.VerifyFunctionCalled();
		}

		[Fact]
		public void Handle_WhenEmpty_RunAbsentAction()
		{
			var handlePresent = new MockAction<string>();
			var handleAbsent = new MockAction();
			var option = Optional<string>.Empty();

			option.Handle(value => handlePresent.Run(value), () => handleAbsent.Run());

			handlePresent.VerifyActionNotCalled();
			handleAbsent.VerifyActionCalled();
		}

		[Fact]
		public void Handle_WhenEmpty_WhenNoAbsent_NothingDone()
		{
			var handlePresent = new MockAction<string>();
			var option = Optional<string>.Empty();

			option.Handle(value => handlePresent.Run(value));

			handlePresent.VerifyActionNotCalled();
		}

		[Fact]
		public void Handle_WhenNull_ReturnAbsentFunctionValue()
		{
			var handlePresent = new MockFunction<string>().RunReturns("present");
			var handleAbsent = new MockFunction<string>().RunReturns("absent");
			var option = Optional<string>.Of(null);

			var result = option.Handle(value => handlePresent.Run(), () => handleAbsent.Run());

			Assert.Equal("absent", result);
			handlePresent.VerifyFunctionNotCalled();
			handleAbsent.VerifyFunctionCalled();
		}

		[Fact]
		public void Handle_WhenNull_RunAbsentAction()
		{
			var handlePresent = new MockAction<string>();
			var handleAbsent = new MockAction();
			var option = Optional<string>.Of(null);

			option.Handle(value => handlePresent.Run(value), () => handleAbsent.Run());

			handlePresent.VerifyActionNotCalled();
			handleAbsent.VerifyActionCalled();
		}

		[Fact]
		public void Handle_WhenNull_WhenNoAbsent_NothingDone()
		{
			var handlePresent = new MockAction<string>();
			var option = Optional<string>.Of(null);

			option.Handle(value => handlePresent.Run(value));

			handlePresent.VerifyActionNotCalled();
		}

		[Fact]
		public void Handle_WhenPresent_ReturnPresentFunctionValue()
		{
			var handlePresent = new MockFunction<string>().RunReturns("present");
			var handleAbsent = new MockFunction<string>().RunReturns("absent");
			var option = Optional<string>.Of("present");

			var result = option.Handle(value => handlePresent.Run(), () => handleAbsent.Run());

			Assert.Equal("present", result);
			handlePresent.VerifyFunctionCalled();
			handleAbsent.VerifyFunctionNotCalled();
		}

		[Fact]
		public void Handle_WhenPresent_RunPresentAction()
		{
			var handlePresent = new MockAction<string>();
			var handleAbsent = new MockAction();
			var option = Optional<string>.Of("present");

			option.Handle(value => handlePresent.Run(value), () => handleAbsent.Run());

			handlePresent.VerifyActionCalled("present");
			handleAbsent.VerifyActionNotCalled();
		}

		[Fact]
		public void Handle_WhenPresent_WhenNoAbsent_RunPresentAction()
		{
			var handlePresent = new MockAction<string>();
			var option = Optional<string>.Of("present");

			option.Handle(value => handlePresent.Run(value));

			handlePresent.VerifyActionCalled("present");
		}

		[Fact]
		public void IsAbsent_ReturnsFalseWhenOptionalIsPresent()
		{
			var option = Optional<string>.Of("present");

			var result = option.IsAbsent;

			Assert.False(result);
		}

		[Fact]
		public void IsAbsent_ReturnsTrueWhenOptionalIsNotPresent()
		{
			var option = Optional<string>.Empty();

			var result = option.IsAbsent;

			Assert.True(result);
		}

		[Fact]
		public void Value_ReturnsTheInnerValueWhenPresent()
		{
			var option = Optional<string>.Of("present");

			var result = option.Value;

			Assert.Equal("present", result);
		}

		[Fact]
		public void Value_ThrowsAnExceptionWhenValueIsNotPresent() { Assert.Throws<ArgumentException>(() => Optional<string>.Empty().Value); }
	}
}