using NUnit.Framework;

namespace CalculatorTests
{
    using Calculator;

    class NumberTests
    {
        private Number number;

        [SetUp]
        public void SetUp()
        {
            number = new Number();
        }

        [Test]
        public void ChangeSignTest()
        {

        }

        [Test]
        public void SqrtBYNegativeNumberTest()
        {
            number.Value = "144";
            number.ChangeSign();
            Assert.Throws<SqrtByNegativeNumberException>(() => number.CalculateSqrt());
        }

    }
}
