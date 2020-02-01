namespace LeetCodeSolution
{
    /*
     * 编写一个算法来判断一个数是不是“快乐数”。

一个“快乐数”定义为：对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和，然后重复这个过程直到这个数变为 1，也可能是无限循环但始终变不到 1。如果可以变为 1，那么这个数就是快乐数。

示例: 

输入: 19
输出: true
解释: 
1^2 + 9^2 = 82
8^2 + 2^2 = 68
6^2 + 8^2 = 100
1^2 + 0^2 + 0^2 = 1

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/happy-number
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     *
     * 解题思路
     *
     * “快慢指针” ,快指针走2步，慢指针走1步。
     *
     * 在一个循环周期结束后，快指针会等于慢指针。
     *
     * 不快乐的数字： 4 → 16 → 37 → 58 → 89 → 145 → 42 → 20 → 4 会一直循环。
     *
     * 结果中，如果是因为1而引起的循环，则为快乐数字。否则，则不是。
     *
     */
    public class Solution202
    {
        public bool IsHappy(int n)
        {
            int slow = n;
            int fast = n;
            do
            {
                slow = Sum(slow);
                fast = Sum(fast);
                fast = Sum(fast);
            } while (fast!=slow);

            return slow == 1;
        }

        private int Sum(int n)
        {
            int sum = 0;

            while (n>0)
            {
                int bit = n % 10;
                sum += bit * bit;
                n = n / 10;
            }

            return sum;
        }
    }
}