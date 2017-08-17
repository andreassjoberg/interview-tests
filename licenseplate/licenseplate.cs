using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace licenseplate
{
    public class Tests
    {
        [Fact]
        public void TestQuick()
        {
            Test(GenerateData('A', 'Z', 'A'));
        }

        [Fact]
        public void TestSlow()
        {
            Test(GenerateData('Z', 'Z', 'A'));
        }

        private static void Test(List<string> data)
        {
            Assert.False(data.HasDuplicates());

            data.Add(data.Last());
            Assert.True(data.HasDuplicates());
        }

        private static List<string> GenerateData(int a, int b, int c)
        {
            var data = new List<string>();
            for (int i = 'A'; i <= a; ++i)
            {
                for (int j = 'A'; j <= b; ++j)
                {
                    for (int k = 'A'; k <= c; ++k)
                    {
                        for (int l = 0; l <= 9; ++l)
                        {
                            for (int m = 0; m <= 9; ++m)
                            {
                                for (int n = 0; n <= 9; ++n)
                                {
                                    data.Add((char)i + "" + (char)j + "" + (char)k + "" + l + "" + m + "" + n);
                                }
                            }
                        }
                    }
                }
            }
            return data;
        }
    }

    static class Implementation
    {
        public static bool HasDuplicates(this List<string> input)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
