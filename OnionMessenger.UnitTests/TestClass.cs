using Xunit;
using OnionMessenger.WebApi.Logic;

namespace OnionMessenger.UnitTests
{
    public class TestClass
    {
       
        TestLogic tl;
        public TestClass()
        {
            this.tl = new TestLogic();
        }
      

        [Fact]
        [Trait("Category","Category1")]
        public void PassingTest()
        {           
           
            Assert.Equal(4, tl.Add(2, 2));
            //Assert.Equal(3, tl.Add(1, 5));
        }

        [Fact]
        public void FailingTest()
        {
            
            Assert.True(tl.Add(2, 3)==4);
        }


    }
}
