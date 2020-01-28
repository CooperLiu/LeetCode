using System;

namespace LeetCodeSolution
{
    /*
     *We are given a list nums of integers representing a list compressed with run-length encoding.

    Consider each adjacent pair of elements [a, b] = [nums[2*i], nums[2*i+1]] (with i >= 0). 
    For each such pair, there are a elements with value b in the decompressed list.

    Return the decompressed list.

     

    Example 1:

    Input: nums = [1,2,3,4]
    Output: [2,4,4,4]
    Explanation: The first pair [1,2] means we have freq = 1 and val = 2 so we generate the array [2].
    The second pair [3,4] means we have freq = 3 and val = 4 so we generate [4,4,4].
    At the end the concatenation [2] + [4,4,4,4] is [2,4,4,4].
     

    Constraints:

    2 <= nums.length <= 100
    nums.length % 2 == 0
    1 <= nums[i] <= 100

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/decompress-run-length-encoded-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     *
     *
     */

    /*
     * 方法1：奇数为个数，偶数为数组元素。
     * 
     */

    /// <summary>
    /// 
    /// </summary>
    public static class Solution1313
    {
        public static int[] DecompressRLElist(int[] nums)
        {
            int arrLen = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                arrLen += nums[i];
            }

            int[] arr = new int[arrLen];
            int arrIdx = 0;

            for (int i = 0; i < nums.Length; i += 2)
            {
                int val = nums[i];
                while (val > 0)
                {
                    arr[arrIdx] = nums[i + 1];
                    val--;
                    arrIdx++;
                }
            }

            return arr;
        }
    }
}