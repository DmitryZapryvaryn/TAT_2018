using NUnit.Framework;
using System;

namespace task_DEV3.Tests
{
    [TestFixture]
    public class NumberBaseConverterTests
    {
        private readonly NumberBaseConverter _numberBaseConverter;

        public NumberBaseConverterTests()
        {
            _numberBaseConverter = new NumberBaseConverter();
        }

        [Test]
        public void GetNewNumberPresentation_SourceNumberLessThanZero_ExpectArgumentException()
        {
            int sourceNumber = -1;
            int newBase = 10;

            Assert.Throws<ArgumentException>
                (
                    () => _numberBaseConverter.GetNewNumberPresentation(sourceNumber, newBase)
                );
        }

        [Test]
        public void GetNewNumberPresentation_NewBaseMinValue_ExpectArgumentOutOfRangeException()
        {
            int sourceNumber = 32;
            int newBase = 1;

            Assert.Throws<ArgumentOutOfRangeException>
                (
                    () => _numberBaseConverter.GetNewNumberPresentation(sourceNumber, newBase)
                );
        }

        [Test]
        public void GetNewNumberPresentation_NewBaseMaxValue_ExpectArgumentOutOfRangeException()
        {
            int sourceNumber = 32;
            int newBase = 21;

            Assert.Throws<ArgumentOutOfRangeException>
                (
                    () => _numberBaseConverter.GetNewNumberPresentation(sourceNumber, newBase)
                );
        }

        [TestCase(15, 2, ExpectedResult = "1111")]
        [TestCase(19, 20, ExpectedResult = "J")]
        public string GetNewNumberPresentation_ValidParameters_ExpectedResult(int a, int b)
        {
            int sourceNumber = a;
            int newBase = b;

            string result = _numberBaseConverter.GetNewNumberPresentation(sourceNumber, newBase);

            return result;
        }
    }
}
