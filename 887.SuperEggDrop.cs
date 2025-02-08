// 887. Super Egg Drop
// You are given k identical eggs and you have access to a building with n floors labeled from 1 to n.
// You know that there exists a floor f where 0 <= f <= n such that any egg dropped at a floor higher than f will break,
// and any egg dropped at or below floor f will not break.
// Each move, you may take an unbroken egg and drop it from any floor x (where 1 <= x <= n). If the egg breaks, you can no
// longer use it. However, if the egg does not break, you may reuse it in future moves.
// Return the minimum number of moves that you need to determine with certainty what the value of f is.

// Example 1:
// Input: k = 1, n = 2
// Output: 2
// Explanation: 
// Drop the egg from floor 1. If it breaks, we know that f = 0.
// Otherwise, drop the egg from floor 2. If it breaks, we know that f = 1.
// If it does not break, then we know f = 2.
// Hence, we need at minimum 2 moves to determine with certainty what the value of f is.
// Example 2:
// Input: k = 2, n = 6
// Output: 3
// Example 3:
// Input: k = 3, n = 14
// Output: 4

// Constraints:
// 1 <= k <= 100
// 1 <= n <= 104


//https://www.youtube.com/watch?v=xsOCvSiSrSs&t=1s&ab_channel=JamesTanton
public class Solution {
    public int SuperEggDrop(int k, int n) {
        // dp[i,j] represents the minimum number of moves needed to determine the critical floor
        // with i moves and j eggs
        int[,] dp = new int[n+1, k+1];

        // Iterate over the number of floors
        for (int i = 1; i <= n; i++) {
            // Iterate over the number of eggs
            for (int j = 1; j <= k; j++) {
                if (i == 1) {
                    // If there's only one move, only one trial is needed
                    // for 1st floor we need only one move
                    dp[i, j] = 1;
                } else if (j == 1) {
                    // If there's only one egg, trials equal to floors because we can only drop from each floor sequentially
                    dp[i, j] = i;
                } else {
                    // Use the formula to fill in the array
                    // Break: Previous floor, with one less egg
                    // Survive: Previous floor with same eggs
                    // plus 1 more move at current state
                    // dp[i-1,j-1] + dp[i-1,j] + 1
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j] + 1;
                }
            }
            // If the number of moves with k eggs is greater than or equal to n floors, return the number of moves
            if (dp[i, k] >= n) {
                return i;
            }
        }

        // In case we iterate through all possible moves without finding a solution, return n
        return n;
    }
}
// Explanation:
// First loop:
// Iterate over the number of moves from 1 to n.
// Second loop:
// Iterate over the number of eggs from 1 to k.
// Special cases:
// If there's only one move (i == 1), only one trial is needed regardless of the number of eggs.
// If there's only one egg (j == 1), then the trials needed are equal to the number of floors because we can only drop from each floor sequentially.
// General case:
// Use the formula dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j] + 1 to fill in the array.
// Early termination:
// If at any point dp[i, k] (the number of moves required with k eggs and i moves) is greater than or equal to n, then return i because we found the minimum number of moves needed to determine the critical floor with k eggs and n floors.
// Default return:
// If the solution isn't found within the loop, return n as the maximum number of moves required (this case usually won't happen with proper logic).

public class Solution {
    public int SuperEggDrop(int k, int n) {
        // dp[j] represents the number of floors that can be checked with j eggs and i moves
        int[] dp = new int[k + 1];
        int moves = 0;

        // Continue until the number of floors checked with k eggs is less than n
        while (dp[k] < n) {
            moves++;
            // Update the dp array from back to front to reuse the array correctly
            for (int j = k; j > 0; j--) {
                dp[j] = dp[j] + dp[j - 1] + 1;
            }
        }

        return moves;
    }
}

// Array Initialization:
// dp[j] represents the maximum number of floors that can be checked with j eggs and i moves.
// Main Loop:
// The loop continues until the number of floors that can be checked with k eggs (dp[k]) is at least n.
// Moves Increment:
// Increment the number of moves in each iteration.
// Update dp Array:
// Update the dp array from back to front. The formula dp[j] = dp[j] + dp[j - 1] + 1 calculates the number of floors that can be checked with j eggs and moves moves.
// This way, each dp[j] stores the number of floors that can be checked with j eggs after moves moves.
// Return Moves:
// Once dp[k] is greater than or equal to n, the number of moves is the answer, and it's returned.
