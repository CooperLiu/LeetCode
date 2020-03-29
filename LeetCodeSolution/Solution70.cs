using System;

namespace LeetCodeSolution
{
    /*
     * 
     * 70. Climbing Stairs
You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Note: Given n will be a positive integer.

Example 1:

Input: 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:

Input: 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
     
         */
    public class Solution70
    {
        public int ClimbStairs(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            //01. 定义数组含义：
            int[] dp = new int[n + 1];

            //02. 初始化条件
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                //03.找到数组元素之间的关系

                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];

        }

        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost == null || cost.Length == 0) return 0;

            int len = cost.Length;

            int[] dp = new int[len];

            dp[0] = cost[0];
            dp[1] = cost[1];

            for (int i = 2; i < len; i++)
            {
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
            }


            return Math.Min(dp[len - 1], dp[len - 2]);
        }

        public int MinPathSum(int[][] grid)
        {
            //定义数组含义
            //数组元素关系
            //初始化条件

            int m = grid.Length;
            int n = grid[0].Length;

            int[,] dp = new int[m, n];


            // dp[i,j] = Math.Min(dp[i-1][j],dp[i][j-1]) + grid[i,j]

            dp[0, 0] = grid[0][0];

            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
            }

            for (int j = 1; j < n; j++)
            {
                dp[0, j] = dp[0, j - 1] + grid[0][j];
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }

            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// 给定两个字符串 text1 和 text2，返回这两个字符串的最长公共子序列。

        /// <example>
        /// 一个字符串的 子序列是指这样一个新的字符串：它是由原字符串在不改变字符的相对顺序的情况下删除某些字符（也可以不删除任何字符）后组成的新字符串。
        /// 例如，"ace" 是 "abcde" 的子序列，但 "aec" 不是 "abcde" 的子序列。两个字符串的「公共子序列」是这两个字符串所共同拥有的子序列。
        /// 若这两个字符串没有公共子序列，则返回 0。
        /// </example>       

        ///来源：力扣（LeetCode）
        ///链接：https://leetcode-cn.com/problems/longest-common-subsequence
        ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence(string text1, string text2)
        {
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                return 0;
            }

            var arr1 = text1.ToCharArray();
            var arr2 = text2.ToCharArray();

            var m = arr1.Length;
            var n = arr2.Length;

            //定义数组
            //数组元素关系
            //初始化条件

            // 末位字符是否相等，如果相等，数组位置加一，如果不相等，需要取相邻的最大值，继续比较下一位。


            /*
             
             \ |  a  b   c   d
             -------------------------
             a |     

             c |

             d |
             -------------------------
             */


            int[,] dp = new int[m + 1, n + 1]; //什么时候长度加一

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (arr1[i - 1] == arr2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            return dp[m,n];


        }
    }

}