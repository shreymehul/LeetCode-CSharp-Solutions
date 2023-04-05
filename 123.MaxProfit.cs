// 123. Best Time to Buy and Sell Stock III

// You are given an array prices where prices[i] is the price of a given stock on the ith day.
// Find the maximum profit you can achieve. You may complete at most two transactions.
// Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
// Example 1:
// Input: prices = [3,3,5,0,0,3,1,4]
// Output: 6
// Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
// Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
// Example 2:
// Input: prices = [1,2,3,4,5]
// Output: 4
// Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
// Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are engaging multiple transactions at the same time. You must sell before buying again.
// Example 3:
// Input: prices = [7,6,4,3,1]
// Output: 0
// Explanation: In this case, no transaction is done, i.e. max profit = 0.

//Based on soln 121
public class Solution {
    public int MaxProfit(int[] prices) {
        int max = prices[prices.Length -1];
        int min = prices[0];
        int[] profit = new int[prices.Length];
        //Move right to left to find max profit
        for(int i = prices.Length - 2; i >= 0; i--){
			//find max till now, so that to find max profit at any buying point.
            max = Math.Max(max, prices[i]);
            profit[i] = Math.Max(profit[i+1], max - prices[i]);
        }
        //Move left to right to find max profit
        for(int i = 1; i < prices.Length; i++){
			//find min till now, so that to find max profit at any selling point.
            min = Math.Min(min, prices[i]);
			//Add in existing profit as we can buy and sell atmost 2 times.
            profit[i] = Math.Max(profit[i-1], (profit[i]) + (prices[i]-min));
        }
        return profit[profit.Length-1];
    }
}