using System.Diagnostics;
using LeetCodeSolution;
using Xunit;

namespace LeetCodeSolutionTests
{
    public class Solution1313_Tests
    {
        [Fact]
        public void DecompressRLElist_Test()
        {
            var arr = new int[] { 1, 2, 3, 4 };

            var watcher = new Stopwatch();

            watcher.Start();

            var decompressArray = Solution1313.DecompressRLElist(arr);

            var totalSec = watcher.ElapsedMilliseconds;

            watcher.Stop();

            Assert.Equal(4, decompressArray.Length);


        }
    }
}