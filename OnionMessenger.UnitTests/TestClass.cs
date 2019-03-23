using System;
using System.Collections.Generic;
using Xunit;

namespace OnionMessenger.UnitTests
{
    public class TestClass
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
            Assert.Equal(3, Add(1, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(3, 2));
        }

        private int Add(int v1, int v2)
        {
            return v1 + v2;
        }
    }
}
