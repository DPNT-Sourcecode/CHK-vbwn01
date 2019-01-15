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
        public void ReturnFalseGivenStringContainsInvalidCharacters(string skus)
        {
            bool isValid = CheckoutSolution.IsInputValid(skus);
            Assert.IsFalse(isValid, $"{skus} should not be valid");
        }

        [TestCase("", ExpectedResult = 0)]
        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("AAAAA", ExpectedResult = 200)]
        [TestCase("AAAAAAAAA", ExpectedResult = 380)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("BB", ExpectedResult = 45)]
        [TestCase("AAAABBBCD", ExpectedResult = 290)]
        [TestCase("EEB", ExpectedResult = 80)]
        [TestCase("EEBB", ExpectedResult = 110)]
        [TestCase("EEBBB", ExpectedResult = 125)]
        [TestCase("F", ExpectedResult = 10)]
        [TestCase("FF", ExpectedResult = 20)]
        [TestCase("FFF", ExpectedResult = 20)]
        [TestCase("FFFFFF", ExpectedResult = 40)]
        [TestCase("GIJ", ExpectedResult = 115)]
        [TestCase("HHHHHHHHHHHHHHHH", ExpectedResult = 135)]
        [TestCase("KKKKK", ExpectedResult = 380)]
        [TestCase("LM", ExpectedResult = 105)]
        [TestCase("NNNOM", ExpectedResult = 130)]
        [TestCase("PPPPPQQQ", ExpectedResult = 280)]
        [TestCase("RRRQQ", ExpectedResult = 180)]
        [TestCase("ST", ExpectedResult = 50)]
        [TestCase("UUUU", ExpectedResult = 120)]
        [TestCase("VV", ExpectedResult = 90)]
        public int CheckoutTest(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}


