// 518. Coin Change II

// You are given an integer array coins representing coins of different denominations and an integer amount representing a total
// amount of money.

// Return the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of 
// the coins, return 0.

// You may assume that you have an infinite number of each kind of coin.

// The answer is guaranteed to fit into a signed 32-bit integer.

 

// Example 1:
// Input: amount = 5, coins = [1,2,5]
// Output: 4
// Explanation: there are four ways to make up the amount:
// 5=5
// 5=2+2+1
// 5=2+1+1+1
// 5=1+1+1+1+1

// Example 2:
// Input: amount = 3, coins = [2]
// Output: 0
// Explanation: the amount of 3 cannot be made up just with coins of 2.

// Example 3:
// Input: amount = 10, coins = [10]
// Output: 1

// Constraints:
// 1 <= coins.length <= 300
// 1 <= coins[i] <= 5000
// All the values of coins are unique.
// 0 <= amount <= 5000


public class Solution {
    public int Change(int amount, int[] coins) {
        return Combination(amount, coins, 0);
    }

    public int Combination(int amount, int[] coins, int index) {
        if (amount == 0) 
            return 1;
        if (index == coins.Length || amount < 0) 
            return 0;

        // Include current coin or skip to the next one
        return Combination(amount - coins[index], coins, index) 
             + Combination(amount, coins, index + 1);
    }
}

//O(amount * n) time complexity and efficiently avoids recomputation.
public class Solution {
    private int[,] memo;

    public int Change(int amount, int[] coins) {
        memo = new int[amount + 1, coins.Length + 1];
        for (int i = 0; i <= amount; i++) 
            for (int j = 0; j <= coins.Length; j++) 
                memo[i, j] = -1;
        return Combination(amount, coins, 0);
    }

    public int Combination(int amount, int[] coins, int index) {
        if (amount == 0) return 1;
        if (index == coins.Length || amount < 0) return 0;
        if (memo[amount, index] != -1) return memo[amount, index];

        memo[amount, index] = Combination(amount - coins[index], coins, index) 
                            + Combination(amount, coins, index + 1);
        return memo[amount, index];
    }
}


//Time: O(amount×coins.Length)
//Space: O(amount)
public class Solution {
    public int Change(int amount, int[] coins) {
        int[] dp = new int[amount + 1];
        dp[0] = 1; // There's one way to make amount 0 — by using no coins

        foreach (var coin in coins) {
            for (int i = coin; i <= amount; i++) {
                dp[i] += dp[i - coin];
            }
        }

        return dp[amount];
    }
}
// Base Case:

// dp[0] = 1 because there's exactly one way to make amount 0, which is by choosing no coins.
// DP Array Update:

// For each coin, iterate from coin to amount and accumulate possible combinations.
// dp[i] += dp[i - coin] counts how many ways we can form i by using coin.
