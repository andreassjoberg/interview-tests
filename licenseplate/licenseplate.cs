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
            var root = new Node('Z' - 'A' + 1);

            foreach (var line in input)
            {
                var exists = true;

                // First character
                if (root.Children[line[0] - 'A'] == null)
                {
                    exists = false;
                    root.Children[line[0] - 'A'] = new Node('Z' - 'A' + 1);
                }

                // Second character
                if (root.Children[line[0] - 'A'].Children[line[1] - 'A'] == null)
                {
                    exists = false;
                    root.Children[line[0] - 'A'].Children[line[1] - 'A'] = new Node('Z' - 'A' + 1);
                }

                // Third character
                if (root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'] == null)
                {
                    exists = false;
                    root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'] = new Node(10);
                }

                // Fourth character
                if (root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'].Children[line[3] - '0'] == null)
                {
                    exists = false;
                    root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'].Children[line[3] - '0'] = new Node(10);
                }

                // Fifth character
                if (root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'].Children[line[3] - '0'].Children[line[4] - '0'] == null)
                {
                    exists = false;
                    root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'].Children[line[3] - '0'].Children[line[4] - '0'] = new Node(10);
                }

                // Sixth character
                if (root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'].Children[line[3] - '0'].Children[line[4] - '0'].Children[line[5] - '0'] == null)
                {
                    exists = false;
                    root.Children[line[0] - 'A'].Children[line[1] - 'A'].Children[line[2] - 'A'].Children[line[3] - '0'].Children[line[4] - '0'].Children[line[5] - '0'] = new Node(0);
                }

                // Check result
                if (exists)
                {
                    return true;
                }
            }

            return false;
        }

        public class Node
        {
            public Node(int size)
            {
                Children = new Node[size];
            }

            public Node[] Children { get; }
        }
    }
}
