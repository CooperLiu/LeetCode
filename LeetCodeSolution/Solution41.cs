using System;

namespace LeetCodeSolution
{
    /*
     * 给定一个未排序的整数数组，找出其中没有出现的最小的正整数。

示例 1:

输入: [1,2,0]
输出: 3
示例 2:

输入: [3,4,-1,1]
输出: 2
示例 3:

输入: [7,8,9,11,12]
输出: 1
说明:

你的算法的时间复杂度应为O(n)，并且只能使用常数级别的空间。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/first-missing-positive
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     *
     * 解题思路
     * 1. 给定的数字有一定的连续性。
     *
     * 2. 抽屉原理，"一个萝卜一个坑"，索引i位置上的数字应该是（i+1），即nums[i] =nums[nums[i-1]-1]
     *
     * 经过交换排序，数组按 nums[i]==i+1 规律排列，如果不符合，则输出。
     *
     */
    public class Solution41
    {
        public int FirstMissingPositive(int[] nums)
        {
            int len = nums.Length;

            for (int i = 0; i < len; i++)
            {
                while (nums[i] > 0 //要最小正整数
                       && nums[i] <= len //小于数组长度，[数组连续性，要求最小正整数输出，所以寻找小于数组长度]
                       && nums[nums[i] - 1] != nums[i]) // 索引与对应的数字，关系：i+1 = num
                {
                    // 满足在指定范围内、并且没有放在正确的位置上，才交换
                    // 例如：数值 3 应该放在索引 2 的位置上
                    swap(nums, nums[i] - 1, i);
                }
            }

            // [1, -1, 3, 4]
            for (int i = 0; i < len; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1; //
                }
            }

            // 都正确则返回数组长度 + 1
            return len + 1;

        }

        private void swap(int[] nums, int idx1, int idx2)
        {
            int t = nums[idx1];
            nums[idx1] = nums[idx2];
            nums[idx2] = t;
        }
    }


    /*
     * 集合 S 包含从1到 n 的整数。不幸的是，因为数据错误，导致集合里面某一个元素复制了成了集合里面的另外一个元素的值，导致集合丢失了一个整数并且有一个元素重复。

给定一个数组 nums 代表了集合 S 发生错误后的结果。你的任务是首先寻找到重复出现的整数，再找到丢失的整数，将它们以数组的形式返回。

示例 1:

输入: nums = [1,2,2,4]
输出: [2,3]
注意:

给定数组的长度范围是 [2, 10000]。
给定的数组是无序的。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/set-mismatch
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     */
    public class Solution645
    {
        public int[] FindErrorNums(int[] nums)
        {
            int len = nums.Length;
            int sum = 0;

            int[] res = new int[2];


            for (int i = 0; i < len; i++)
            {
                nums[i] = nums[i] > 0 ? nums[i] : nums[i] * -1;

                sum += nums[i];

                if (nums[nums[i] - 1] < 0)
                {
                    res[0] = nums[i];
                }
                else
                {
                    nums[nums[i] - 1] *= -1;
                }

            }

            res[1] = len * (len + 1) / 2 - sum + res[0];

            return res;
        }

        public int[] FindErrorNums2(int[] nums)
        {
            int sum = 0, dup = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] > 0)
                {
                    nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
                }
                else
                {
                    dup = Math.Abs(nums[i]);
                }
                sum += Math.Abs(nums[i]);
            }

            return new[] { dup, (len * (len + 1)) / 2 - sum + dup };


        }
    }
}