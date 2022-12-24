// 790. Domino and Tromino Tiling

// You have two types of tiles: a 2 x 1 domino shape and a tromino shape. You may rotate these shapes.
// Given an integer n, return the number of ways to tile an 2 x n board. Since the answer may be very large, return it modulo 109 + 7.
// In a tiling, every square must be covered by a tile. Two tilings are different if and only if there are two 4-directionally adjacent cells on the board such that exactly one of the tilings has both squares occupied by a tile.

// Example 1:
// Input: n = 3
// Output: 5
// Explanation: The five different ways are show above.
// Example 2:
// Input: n = 1
// Output: 1
// Constraints:
// 1 <= n <= 1000

public class Solution {
    public int NumTilings(int n) {
        if(n<3) return n;
        long[] dp = new long[n+1];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;
        for(int i = 3; i <= n; i++ ){
            dp[i] = (2*dp[i-1] + dp[i-3]) % 1000000007;
        }
        return (int)dp[n];
    }
}


// There is a mutual recursion in two variables 𝑓(𝑛) for the 𝑛×2 grid and 𝑔(𝑛) for the 𝑛×2 grid with a single square sticking out. 
// It does not matter where the square sticks out (first or second row) because their number of tilings is the same.
// Note the trominos indeed come in pairs, but they do not need to form a 3×2 block. 
// You can place horizontal dominoes in between. Now that I look at it, it seems there is a recursion with one 𝑓(𝑛) 
// if you look at a tromino and its matching partner. This picture suggests 𝑓(7)=𝑓(6)+𝑓(5)+2𝑓(4)+2𝑓(3)+⋯+2𝑓(1)+2𝑓(0). 
// Sounds like a promising recursion to me.

// If my initial computations are right, this suggests 1,1,2,5,11,24,53,117, ... which is OEISA052980. 
// This lists another recurrence however. Would be fun if they match.

// PS. Yes! Recursions are the same. 
// 𝑓(𝑛)=𝑓(𝑛−1)+𝑓(𝑛−2)+2∑𝑛−3𝑘=0𝑓(𝑘). 
// Then subtract 𝑓(𝑛)−𝑓(𝑛−1)=𝑓(𝑛−1)+𝑓(𝑛−3). 
// Thus 𝑓(𝑛)=2𝑓(𝑛−1)+𝑓(𝑛−3), which is in the OEIS.