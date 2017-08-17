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
            s = s.ToLower()
                 .Replace(" ", "")
                 .Replace(",", "")
                 .Replace(".", "");
            for (int i = 0, j = s.Length - 1; i < j; ++i, --j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
