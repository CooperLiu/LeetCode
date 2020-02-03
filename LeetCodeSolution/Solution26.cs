namespace LeetCodeSolution
{
    /*
     * 给定一个排序数组，你需要在原地删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。

不要使用额外的数组空间，你必须在原地修改输入数组并在使用 O(1) 额外空间的条件下完成。

示例 1:

给定数组 nums = [1,1,2], 

函数应该返回新的长度 2, 并且原数组 nums 的前两个元素被修改为 1, 2。 

你不需要考虑数组中超出新长度后面的元素。
示例 2:

给定 nums = [0,0,1,1,1,2,2,3,3,4],

函数应该返回新的长度 5, 并且原数组 nums 的前五个元素被修改为 0, 1, 2, 3, 4。

你不需要考虑数组中超出新长度后面的元素。
说明:

为什么返回数值是整数，但输出的答案是数组呢?

请注意，输入数组是以“引用”方式传递的，这意味着在函数里修改输入数组对于调用者是可见的。

你可以想象内部操作如下:

// nums 是以“引用”方式传递的。也就是说，不对实参做任何拷贝
int len = removeDuplicates(nums);

// 在函数里修改输入数组对于调用者是可见的。
// 根据你的函数返回的长度, 它会打印出数组中该长度范围内的所有元素。
for (int i = 0; i < len; i++) {
    print(nums[i]);
}

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        解题思路：
        
        输入[1,1,2,2,3]，数组是有序数组。
        快慢指针，比较前后值，
            如果相同，慢指针不移动，快指针移动。
            如果慢指针与快指针的索引数组项不同，
         s f
        [1,1,2,2,3]
        --------------0.相同，慢指针不动，快指针+1
         s   f
        [1,1,2,2,3]
        --------------1.不同，交换nums[slow+1]=nums[fast]，慢指针+1，快指针+1
           s   f
        [1,2,2,2,3]
        --------------2.相同，慢指针不动，快指针+1，
           s     f       
        [1,2,3,2,3]
        --------------3.不同，交换nums[slow+1]=nums[fast]，慢指针+1，快指针小于数组长度，终止循环。
             s   f
        [1,2,3,2,3]
        --------------4.循环终止。

     */
    public class Solution26
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length < 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return 1;
            }

            int len = nums.Length;

            int slow = 0;

            for (int fast = 1; fast < len; fast++)
            {
                if (nums[slow] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
            }
            return slow + 1; //返回慢指针+1
        }


        public int RemoveDuplicates2(int[] nums)
        {
            if (nums == null || nums.Length <= 0)
            {
                return 0;
            }

            int slow = 0;
            int fast = 1;

            while (fast < nums.Length)
            {
                if (nums[slow]!=nums[fast])
                {
                    nums[slow + 1] = nums[fast];
                    slow++;
                }

                fast++;
            }

            return slow + 1;
        }
    }
}