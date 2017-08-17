using System;
using Xunit;

namespace palindrome
{
    public class Tests
    {
        [Theory]
        [InlineData("A Santa at Nasa", true)]
        [InlineData("deleveled", true)]
        [InlineData("Dumb  mud", true)]
        [InlineData("Hello world", false)]
        public void Test(string input, bool expected)
        {
            Assert.Equal(expected, input.IsPalindrome());
        }
    }

    static class Implementation
    {
        public static bool IsPalindrome(this string s)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
