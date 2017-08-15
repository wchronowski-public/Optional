using System;
using System.Collections.Generic;
using Xunit;

namespace Optional.Core.Tests
{
	public class EnumerableExtensionTest
	{
		[Fact]
		public void FirstOrOptional_WhenMatchingObjects_ReturnFirst()
		{
			var items = new List<string> {"one", "matchingObject", "two", "three"};

			var result = items.FirstOrOptional(i => i.Equals("matchingObject"));

			result.Handle(value => Assert.Equal(value, "matchingObject"), () => Assert.True(false, "Incorrect value"));
		}

		[Fact]
		public void FirstOrOptional_WhenMultipleMatchingObjects_ReturnFirst()
		{
			var items = new List<string> {"one", "two", "three", "three"};

			var result = items.FirstOrOptional(i => i.Equals("three"));

			result.Handle(value => Assert.Equal(value, "three"), () => Assert.True(false, "Incorrect value"));
		}

		[Fact]
		public void FirstOrOptional_WhenNoMatchingObjects_ReturnEmpty()
		{
			var items = new List<string> {"one", "two", "three"};

			var result = items.FirstOrOptional(i => i.Equals("number"));

			Assert.Equal(result, Optional<string>.Empty());
		}

		[Fact]
		public void FirstOrOptional_WhenNoObjects_ReturnEmpty()
		{
			var items = new List<string>();

			var result = items.FirstOrOptional();

			Assert.Equal(result, Optional<string>.Empty());
		}

		[Fact]
		public void FirstOrOptional_WhenObjects_ReturnFirst()
		{
			var items = new List<string> {"one", "two", "three"};

			var result = items.FirstOrOptional();

			result.Handle(value => Assert.Equal(value, "one"), () => Assert.True(false, "Incorrect value"));
		}

		[Fact]
		public void SingleOrOptional_WhenMatchingObjects_ReturnSingle()
		{
			var items = new List<string> {"one", "matchingObject", "two", "three"};

			var result = items.SingleOrOptional(i => i.Equals("matchingObject"));

			result.Handle(value => Assert.Equal(value, "matchingObject"), () => Assert.True(false, "Incorrect value"));
		}

		[Fact]
		public void SingleOrOptional_WhenMultipleMatchingObjects_ThrowInvalidOperationException()
		{
			var items = new List<string> {"one", "two", "three", "three"};

			Assert.Throws<InvalidOperationException>(() => items.SingleOrOptional(i => i.Equals("three")));
		}

		[Fact]
		public void SingleOrOptional_WhenNoMatchingObjects_ReturnEmpty()
		{
			var items = new List<string> {"one", "two", "three"};

			var result = items.SingleOrOptional(i => i.Equals("number"));

			Assert.Equal(result, Optional<string>.Empty());
		}

		[Fact]
		public void SingleOrOptional_WhenNoObjects_ReturnEmpty()
		{
			var items = new List<string>();

			var result = items.SingleOrOptional();

			Assert.Equal(result, Optional<string>.Empty());
		}

		[Fact]
		public void SingleOrOptional_WhenObjects_ThrowInvalidOperationException()
		{
			var items = new List<string> {"one", "two", "three"};

			Assert.Throws<InvalidOperationException>(() => items.SingleOrOptional());
		}
	}
}