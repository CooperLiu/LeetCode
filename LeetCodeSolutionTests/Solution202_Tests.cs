using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution202_Tests
    {
        [Fact]
        public void IsHappy_Test()
        {
            var solution = new Solution202();

            var res = solution.IsHappy(19);

            Assert.True(res);

            var res2 = solution.IsHappy(4);

            Assert.False(res2);
        }
    }
}