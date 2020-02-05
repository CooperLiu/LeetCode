using System;

namespace LeetCodeSolution
{
    /*
     *给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

示例 1：

输入: "babad"
输出: "bab"
注意: "aba" 也是一个有效答案。
示例 2：

输入: "cbbd"
输出: "bb"

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/longest-palindromic-substring
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     *
     *
     * 方法1：中间扩散法
     *  0   1   2   3   4
     * -------------------
     * [b] [a] [b] [a] [b]
     *  |   |   |   |   |
     *    |   |   |   |
     *
     * 1) 不确认回文子串的长度是奇数、偶数。两种情况
     * 2）遍历范围：索引0和n-1不用扩散，因为是边缘无法扩散。
     * 3）
     */
    public class Solution5
    {
        public string LongestPalindrome(string s)
        {
            int len = s.Length;

            if (len < 2)
            {
                return s;
            }

            int left = 0;
            int right = 0;

            for (int i = 0; i < len; i++)
            {
                int oddIdx = CenterSpread(s, i, i);
                int evenIdx = CenterSpread(s, i, i + 1);

                var maxIdx = oddIdx > evenIdx ? oddIdx : evenIdx;

                if (maxIdx > right - left + 1)
                {
                    right = i + maxIdx / 2;
                    left = i - (maxIdx - 1) / 2;
                }
            }

            return s.Substring(left, right - left + 1);
        }

        private int CenterSpread(string s, int left, int right)
        {
            int len = s.Length;

            while (left >= 0 && right < len && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;

            // return s.Substring(i + 1, j); //当跳出循环时，左右两个字符不相等。
        }


    }
}