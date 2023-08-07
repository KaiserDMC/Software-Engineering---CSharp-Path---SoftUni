using SummatorApp;
using NUnit.Framework;

namespace TestingDemo.UnitTests
{

    using NUnit.Framework;
    public class SummatorUnitTests
    {
        [Test]
        public void Test_SumTwoNumbers()
        {
            var summator = new Summator();
            var sum = summator.Sum(new int[] { 1, 2 });
            Assert.AreEqual(3, sum);
        }
    }
}



