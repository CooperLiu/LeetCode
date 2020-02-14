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

    public class Solution645_Test
    {
        [Fact]
        public void FindErrorNums_Test()
        {
            var solution = new Solution645();

            var res = solution.FindErrorNums(new[] {1,2,2,4 });


            Assert.Equal(2,res.Length);

            Assert.Equal(2,res[0]);
            Assert.Equal(3,res[1]);

        }
    }
}