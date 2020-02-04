using System;
using System.Collections.Generic;
using System.Linq;
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
            var nums1 = new[] {-1, 0, 1, 2, -1, -4};
            var nums2 = new[] { 1, -1, -1, 0 };

            var res1 = solution.ThreeSum(nums1);
            var res2 = solution.ThreeSum(nums2);

           //var res = ThreeSum(new []{ 1, -1, -1, 0 });

            Assert.Equal(2, res1.Count);
            Assert.Equal(1, res2.Count);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length < 3) return new List<IList<int>>();

            IList<IList<int>> result = new List<IList<int>>();

            //sort

            nums = nums.OrderBy(a => a).ToArray();

            int len = nums.Length;

            for (int i = 0; i < len - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int mid = i + 1;
                    int end = len - 1;
                    int sum = 0 - nums[i];

                    while (mid < end)
                    {
                        if (nums[mid] + nums[end] == sum)
                        {
                            result.Add(new[] { nums[i], nums[mid], nums[end] });

                            while (mid < end && nums[mid] == nums[mid + 1]) mid++;
                            while (mid < end && nums[end] == nums[end - 1]) end--;
                            mid++;
                            end--;
                        }
                        else if (nums[mid] + nums[end] < sum)
                        {
                            while (mid < end && nums[mid] != nums[mid + 1]) mid++;
                            mid++;
                        }
                        else
                        {
                            while (mid < end && nums[end] != nums[end - 1]) end--;
                            end--;
                        }
                    }

                }

            }

            return result;
        }
    }
}