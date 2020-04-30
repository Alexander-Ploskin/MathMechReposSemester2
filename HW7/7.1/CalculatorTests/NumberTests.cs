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
            number.Value = "6.25";
        }

        [Test]
        public void ChangeSignTest()
        {
            number.ChangeSign();
            Assert.AreEqual(-6.25, double.Parse(number.Value, System.Globalization.CultureInfo.InvariantCulture));
            number.ChangeSign();
            Assert.AreEqual(6.25, double.Parse(number.Value, System.Globalization.CultureInfo.InvariantCulture));
        }

        [Test]
        public void SqrtTest()
        {
            number.CalculateSqrt();
            Assert.AreEqual(2.5, double.Parse(number.Value, System.Globalization.CultureInfo.InvariantCulture));
        }

        [Test]
        public void SqrtByNegativeNumberTest()
        {
            number.ChangeSign();
            Assert.Throws<SqrtByNegativeNumberException>(() => number.CalculateSqrt());
        }

    }
}
