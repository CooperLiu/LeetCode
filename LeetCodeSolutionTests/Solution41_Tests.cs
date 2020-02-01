using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution41_Tests
    {
        [Fact]
        public void FirstMissingPositive_Test()
        {
            var test1 = new int[] { 7, 8, 9, 11, 12 };

            var solution = new Solution41();

            var res = solution.FirstMissingPositive(test1);

            Assert.Equal(1,res);
        }
    }
}