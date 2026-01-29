using Xunit;
using System;

namespace Q2_exception.Tests
{
    public class AdderTests
    {
        [Fact]
        public void Add_ValidNumbers_ReturnsSum()
        {
            Assert.Equal(8, Program.Adder(3, 5));
        }

        [Fact]
        public void Add_Overflow_ThrowsException()
        {
            Assert.Throws<OverflowException>(
                () => Program.Adder(int.MaxValue, 1)
            );
        }

        [Fact]
        public void SafeAdder_NegativeInput_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => Program.SafeAdder(-1, 5)
            );
        }

        [Fact]
        public void SafeAdder_ValidInput_ReturnsSum()
        {
            Assert.Equal(10, Program.SafeAdder(4, 6));
        }
    }
}