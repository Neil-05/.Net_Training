using Xunit;

namespace Q1_ADD.Tests
{
    public class AdderTests
    {
        [Fact]
        public void Add_TwoPositiveNumbers()
        {
            Assert.Equal(8, Program.Adder(3, 5));
        }

        [Fact]
        public void Add_WithZero()
        {
            Assert.Equal(5, Program.Adder(5, 0));
        }

        [Fact]
        public void Add_NegativeNumbers()
        {
            Assert.Equal(-8, Program.Adder(-3, -5));
        }
    }
}