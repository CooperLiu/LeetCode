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
}