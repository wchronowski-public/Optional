using System;
using Xunit;

namespace Optional.Core.Tests {
    public class OptionalTest {
        [Fact]
        public void Handle_ReturnsTheResultOfTheFirstLambdaWhenValueIsPresent() {
            var option = Optional<string>.Of("present");

            var result = option.Handle(value => value, () => "absent");

            Assert.Equal("present", result);
        }

        [Fact]
        public void Handle_ReturnsTheResultOfTheSecondLambdaWhenValueIsNull() {
            var option = Optional<string>.Of(null);

            var result = option.Handle(value => value, () => "absent");

            Assert.Equal("absent", result);
        }

        [Fact]
        public void Handle_ReturnsTheResultOfTheSecondLambdaWhenValueIsEmpty() {
            var option = Optional<string>.Empty();

            var result = option.Handle(value => value, () => "absent");

            Assert.Equal("absent", result);
        }

        [Fact]
        public void IsAbsent_ReturnsFalseWhenOptionalIsPresent() {
            var option = Optional<string>.Of("present");

            var result = option.IsAbsent;

            Assert.False(result);
        }

        [Fact]
        public void IsAbsent_ReturnsTrueWhenOptionalIsNotPresent() {
            var option = Optional<string>.Empty();

            var result = option.IsAbsent;

            Assert.True(result);
        }

        [Fact]
        public void Value_ReturnsTheInnerValueWhenPresent() {
            var option = Optional<string>.Of("present");

            var result = option.Value;

            Assert.Equal("present", result);
        }

        [Fact]
        public void Value_ThrowsAnExceptionWhenValueIsNotPresent() {
            // ReSharper disable once UnusedVariable
            Assert.Throws<ArgumentException>(() => {
                var value = Optional<string>.Empty().Value;
            });
        }
    }
}