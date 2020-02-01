using System;

namespace LeetCodeSolution
{
    /*
     *给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。

如果你最多只允许完成一笔交易（即买入和卖出一支股票），设计一个算法来计算你所能获取的最大利润。

注意你不能在买入股票前卖出股票。

示例 1:

输入: [7,1,5,3,6,4]
输出: 5
解释: 在第 2 天（股票价格 = 1）的时候买入，在第 5 天（股票价格 = 6）的时候卖出，最大利润 = 6-1 = 5 。
     注意利润不能是 7-1 = 6, 因为卖出价格需要大于买入价格。
示例 2:

输入: [7,6,4,3,1]
输出: 0
解释: 在这种情况下, 没有交易完成, 所以最大利润为 0。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
     *
     *
     * 解题思路
     * 一、 动态规划
     *
     */
    public class Solution121
    {
        public int MaxProfit(int[] prices)
        {
            int len = prices.Length;

            if (len < 2)
            {
                return 0;
            }

            /*
             *  // 0：不进行任何操作
                // 1：用户执行了一次买入操作
                // 2：用户执行了一次卖出操作

                // 状态转移方程：
                // dp[i][0] 永远等于 0
                // dp[i][1] = max(dp[i - 1][1], dp[i - 1][0] - prices[i])
                // dp[i][2] = max(dp[i - 1][2], dp[i - 1][1] + prices[i])


                // 注意：如果是 `[7, 6, 5, 4, 3]` 这种波动，应该不交易，
                // 因此输出是：max(dp[len - 1][0], dp[len - 1][2])

             */

            int[,] dp = new int[len, 3];

            dp[0, 0] = 0;// 如果第0天（不进行任何操作），则收益为0
            dp[0, 1] = -prices[0]; //如果第0天执行（买入），则收益为负买入价格
            dp[0, 2] = 0; // 前提条件：现有买入，才能卖出，所以第一天不能执行卖出，即收益为0

            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = 0; //无操作
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]); // 买入
                dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 1, 1] + prices[i]); // 卖出
            }

            return Math.Max(dp[len - 1,0], dp[len - 1,2]);  //前提是先有买入再有卖出，只有不操作或者卖出才能影响正向收益。
        }

    }
}