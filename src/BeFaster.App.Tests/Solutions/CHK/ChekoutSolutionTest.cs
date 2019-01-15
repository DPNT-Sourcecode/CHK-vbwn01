using NUnit.Framework;
using BeFaster.App.Solutions.CHK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class ChekoutSolutionTest
    {
        [TestCase("!")]
        [TestCase(" ")]
        [TestCase("2")]
        [TestCase("J")]
        public void ReturnFalseGivenStringContainsInvalidCharacters(string skus)
        {
            bool isValid = CheckoutSolution.IsInputValid(skus);
            Assert.IsFalse(isValid, $"{skus} should not be valid");
        }

        [TestCase("", ExpectedResult = 0)]
        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("BB", ExpectedResult = 45)]
        [TestCase("AAAABBBCD", ExpectedResult = 290)]
        public int CheckoutTest(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}




