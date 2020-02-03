using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution26_Tests
    {
        [Fact]
        public void RemoveDuplicates2_Test()
        {
            var solution = new Solution26();

            var res = solution.RemoveDuplicates2(new[] { 1, 1, 2, 2, 3 });

            Assert.Equal(3,res);
        }
    }
}