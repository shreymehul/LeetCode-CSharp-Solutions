// 309. Best Time to Buy and Sell Stock with Cooldown
// You are given an array prices where prices[i] is the price of a given stock on the ith day.
// Find the maximum profit you can achieve. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times) with the following restrictions:
// After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).
// Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
// Example 1:
// Input: prices = [1,2,3,0,2]
// Output: 3
// Explanation: transactions = [buy, sell, cooldown, buy, sell]
// Example 2:
// Input: prices = [1]
// Output: 0
// Constraints:
// 1 <= prices.length <= 5000
// 0 <= prices[i] <= 1000


public class Solution {
    public int MaxProfit(int[] prices) {
        /**
        there can be two types of profit we need to track
        sellProfit[i] - profit earned by selling on ith day
        restProfit[i] - profit earned by resting on ith day
        */
        int sellProfit = 0;
        int restProfit = 0;
        int prevDayProfit = 0;
        for(int i = 1; i < prices.Length; i++){
            prevDayProfit = sellProfit;
            //the current sellProfit is either by selling on ith day or by resting on ith day
            sellProfit = Math.Max(sellProfit + prices[i] - prices[i-1], restProfit);
            restProfit = Math.Max(prevDayProfit, restProfit);
        }   
        return Math.Max(sellProfit,restProfit);
    }
}
