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
}