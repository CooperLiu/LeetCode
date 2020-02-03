using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolution
{
    /*
     *给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组。

注意：答案中不可以包含重复的三元组。

 

示例：

给定数组 nums = [-1, 0, 1, 2, -1, -4]，

满足要求的三元组集合为：
[
  [-1, 0, 1],
  [-1, -1, 2]
]

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/3sum
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        解题思路：排序+快慢指针

        算法流程：
1.特判，对于数组长度 n，如果数组为 null 或者数组长度小于 33，返回 [][]。
2.对数组进行排序。
3. 遍历排序后数组：
- 若 nums[i]>0：因为已经排序好，所以后面不可能有三个数加和等于 0，直接返回结果。
- 对于重复元素：跳过，避免出现重复解
令左指针 L=i+1，右指针 R=n-1，当 L<R 时，执行循环：
当 nums[i]+nums[L]+nums[R]==0，执行循环，判断左界和右界是否和下一位置重复，去除重复解。并同时将 L,R移到下一位置，寻找新的解
若和大于 0，说明 nums[R] 太大，R 左移
若和小于 0，说明 nums[L] 太小，L 右移

     *
     */
    public class Solution15
    {
        /// <summary>
        /// 三数之和等于零
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            var result = new List<IList<int>>();

            //sort

            nums = nums.OrderBy(a => a).ToArray(); //[-4,-1,-1,0,1,2]

            int len = nums.Length;

            for (int i = 0; i < len; i++)
            {

                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))//因为数组已经排序，则相邻有可能相等
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
                            while (mid < end && nums[mid] == nums[mid + 1]) mid++;
                            mid++;
                        }
                        else
                        {
                            while (mid < end && nums[end] == nums[end - 1]) end--;
                            end--;
                        }
                    }

                }

            }

            return result;

        }
    }
}