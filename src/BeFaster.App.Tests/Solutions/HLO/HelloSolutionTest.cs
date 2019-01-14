using BeFaster.App.Solutions.SUM;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [TestCase("John", ExpectedResult = "Hello, John!")]
        public string ComputeSum(string friendName)
        {
            return "Hello, " + friendName + "!";
        }
    }
}

