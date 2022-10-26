// 70. Climbing Stairs
// You are climbing a staircase. It takes n steps to reach the top.
// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 // Example 1:

// Input: n = 2
// Output: 2
// Explanation: There are two ways to climb to the top.
// 1. 1 step + 1 step
// 2. 2 steps
// Example 2:

// Input: n = 3
// Output: 3
// Explanation: There are three ways to climb to the top.
// 1. 1 step + 1 step + 1 step
// 2. 1 step + 2 steps
// 3. 2 steps + 1 step

//Approch 1 | Recursion
public class Solution {
    int[] count = new int[46];
    public int ClimbStairs(int n) {
        if(n < 0)
            return 0;
        if(n == 0)
            return 1;
        if(count[n]!=0)
            return count[n];
        int rcount1 = ClimbStairs(n-1);
        int rcount2 = ClimbStairs(n-2);
        
        count[n] = rcount1 + rcount2;
        return count[n] ;
    }
}
//Approch 2 | Fibnoci
public class Solution {
    public int ClimbStairs(int n) {
        int[] fib = new int[n+1];
        fib[0] = 0;
        if(n > 0){
            fib[1] = 1;
            if(n > 1){
                for(int i = 2; i <= n; i++)
                    fib[i] = fib[i-1] + fib[i-2];
            }
        }
        return fib[n];
    }
}