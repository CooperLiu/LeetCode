using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution15_Tests
    {
        [Fact]
        public void ThreeSum_Test()
        {
            var solution = new Solution15();

            var res = solution.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });

            Assert.Equal(2, res.Count);
        }
    }
}