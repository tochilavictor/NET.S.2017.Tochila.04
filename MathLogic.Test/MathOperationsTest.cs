using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MathLogic;

namespace MathLogic.Test
{
    [TestFixture]
    public class MathOperationsTest
    {
        [TestCase(8, 3, 0.001, 2)]
        [TestCase(25, 2, 0.00001, 5)]
        [TestCase(27, 3, 0 , 3)]
        [TestCase(1024, 10, 0.00001, 2)]
        [TestCase(10, 2, 0.001, 3.1622)]
        public void SqrtNewton_GoodRangesAndResults_PositiveTest(double number, int power, double accuracy,double expectedResult)
        {
            double actual = MathOperations.SqrtNewton(number, power, accuracy);

            Assert.True(Math.Abs(actual - expectedResult) <= accuracy);
        }

        [TestCase(4, ExpectedResult = 2)]
        [TestCase(25, ExpectedResult = 5)]
        [TestCase(13689, ExpectedResult = 117)]
        [TestCase(121, ExpectedResult = 11)]
        public double SqrtNewton_OneArgument_PositiveTest(double number)
        {
            return MathOperations.SqrtNewton(number);
        }

        [TestCase(8, 2, 0.00001, 3)]
        [TestCase(25, 2, 0.001, 3)]
        [TestCase(27, 3, 0.00001, 3.5)]
        [TestCase(4, 2, 0.00001, 2.02)]
        public void SqrtNewton_GoodRangesAndBadResults_NegativeTest(double number, int power, double accuracy, double expectedResult)
        {
            double actual = MathOperations.SqrtNewton(number, power, accuracy);

            Assert.False(Math.Abs(actual - expectedResult) <= accuracy);
        }

        [TestCase(-8, 2, 0.00001, 3)]
        [TestCase(25, -2, 0.001, 3)]
        [TestCase(27, 3,- 0.00001, 3.5)]
        [TestCase(-4,-2, 0.00001, 2.02)]
        public void SqrtNewton_NegativeNumberOrPowerOrAccuracy_ExpectedIndexOutOfRangeException(double number, int power, double accuracy, double expectedResult)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.SqrtNewton(number, power, accuracy));
        }
    }
}
