using System.Text;
using Xunit;

namespace Task_DEV2.Tests
{
    public class EvenCharStringCreatorTests
    {
        private readonly EvenCharStringCreator _evenCharStringCreator;

        public EvenCharStringCreatorTests()
        {
            _evenCharStringCreator = new EvenCharStringCreator();
        }

        [Fact]
        public void GetEvenCharSequance_WhenInputStringIsEmpty_ShouldReturnEmptyString()
        {
            string input = string.Empty;

            StringBuilder result = _evenCharStringCreator.GetEvenCharSequence(input);

            Assert.Equal(result.ToString(), string.Empty);
        }

        [Fact]
        public void GetEvenCharSequance_WhenInputSimpleString_ExpectCorrectResult()
        {
            string input = "abcdefg";
            string expectOuput = "aceg";

            StringBuilder result = _evenCharStringCreator.GetEvenCharSequence(input);

            Assert.Equal(result.ToString(), expectOuput);
        }
    }
}
