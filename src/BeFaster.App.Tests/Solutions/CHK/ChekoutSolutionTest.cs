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
        [TestCase("")]
        [TestCase("!")]
        [TestCase(" ")]
        [TestCase("2")]
        public void ReturnFalseGivenStringContainsInvalidCharacters(string skus)
        {
            bool isValid = CheckoutSolution.IsInputValid(skus);
            Assert.IsFalse(isValid, $"{skus} should not be valid");
        }
    }
}

