using SkalProj_Datastrukturer_Minne;

namespace SkalProj_Datastrukturer_MinneTests
{
    public class HelperTests
    {
        [Fact]
        public void ReverseString_Returns_Reverse_String()
        {
            string expected = "gnirts tseT";

            Assert.Equal(Helpers.ReverseString("Test string"), expected);
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("[]", true)]
        [InlineData("{}", true)]
        [InlineData("([{}])", true)]
        [InlineData("([{])", false)]
        [InlineData("test)", false)]
        [InlineData("test[", false)]
        [InlineData("test())", false)]
        [InlineData("test()(", false)]
        [InlineData("test()(fds fsdf", false)]
        [InlineData("(test()sdfsd[])", true)]
        [InlineData("List<int> list = new List<int>() { 1, 2, 3, 4 }", true)]
        [InlineData("List<int> list = new List<int>() { 1, 2, 3, 4 );", false)]
        public void IsParanthesisCorrect(string input, bool expectedResult)
        {
            Assert.Equal(expectedResult, Helpers.IsParanthesisCorrect(input));
        }
    }
}