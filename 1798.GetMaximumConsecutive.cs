// 1798. Maximum Number of Consecutive Values You Can Make
// You are given an integer array coins of length n which represents the n coins that you own. The value of the ith coin is coins[i]. You can make some value x if you can choose some of your n coins such that their values sum up to x.
// Return the maximum number of consecutive integer values that you can make with your coins starting from and including 0.
// Note that you may have multiple coins of the same value.

// Example 1:
// Input: coins = [1,3]
// Output: 2
// Explanation: You can make the following values:
// - 0: take []
// - 1: take [1]
// You can make 2 consecutive integer values starting from 0.
// Example 2:
// Input: coins = [1,1,1,4]
// Output: 8
// Explanation: You can make the following values:
// - 0: take []
// - 1: take [1]
// - 2: take [1,1]
// - 3: take [1,1,1]
// - 4: take [4]
// - 5: take [4,1]
// - 6: take [4,1,1]
// - 7: take [4,1,1,1]
// You can make 8 consecutive integer values starting from 0.
// Example 3:
// Input: nums = [1,4,10,3,1]
// Output: 20

// Constraints:
// coins.length == n
// 1 <= n <= 4 * 104
// 1 <= coins[i] <= 4 * 104

public class Solution {
    public int GetMaximumConsecutive(int[] coins) {
        // Sort the coins array in ascending order to process them from smallest to largest
        Array.Sort(coins);
        
        // Initialize sum to 1. This represents the smallest value we are currently able to form.
        int sum = 1;
        
        // Iterate through each coin in the sorted array
        for(int i = 0; i < coins.Length; i++){
            // If the current coin is greater than the sum we can currently form + 1,
            // we can't use this coin to form a consecutive sum, so we break out of the loop.
            if(coins[i] >= sum + 1)
                break;
            
            // Otherwise, we add the current coin's value to sum,
            // meaning we can now form all sums up to the new value of sum.
            sum += coins[i];
        }
        
        // Return the maximum sum we can form consecutively
        return sum;
    }
}


// Sorting the Array: We sort the coins array to ensure we process the smallest coins first. This helps in forming the smallest possible sums consecutively.
// Initial Sum: We initialize sum to 1, representing the smallest value we aim to form consecutively.
// Iterating Through Coins: We loop through each coin in the sorted array.
// Checking If Coin Can Be Used: We check if the current coin is greater than sum + 1. If it is, we break out of the loop because we won't be able to form a consecutive sum with this coin or any larger ones.
// Updating Sum: If the coin can be used, we add its value to sum. This allows us to form all sums up to the new value of sum.
// Returning the Result: Finally, we return the value of sum, which represents the maximum consecutive sum we can form with the given coins.