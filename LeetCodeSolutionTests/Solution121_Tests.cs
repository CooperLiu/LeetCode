using System.Linq;
using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution121_Tests
    {
        [Fact]
        public void MaxProfit_Test()
        {
            var solution = new Solution121();

            var res = solution.MaxProfit(new[] { 7, 1, 5, 3, 6, 4 });

            Assert.Equal(5, res);
        }
    }

    public class Solution5_Tests
    {
        [Fact]
        public void LongestPalindrome_Test()
        {
            var solution = new Solution5();

            var res = solution.LongestPalindrome("cbbd");

            Assert.Equal("bb", res);
        }
    }
}