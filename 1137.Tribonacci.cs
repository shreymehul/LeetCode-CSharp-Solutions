// 1137. N-th Tribonacci Number

// The Tribonacci sequence Tn is defined as follows: 

// T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.

// Given n, return the value of Tn.

// Example 1:

// Input: n = 4
// Output: 4
// Explanation:
// T_3 = 0 + 1 + 1 = 2
// T_4 = 1 + 1 + 2 = 4
// Example 2:

// Input: n = 25
// Output: 1389537
public class Solution {
    public int Tribonacci(int n) {
        int[] trib = new int[n+1];
        trib[0] = 0;
        if(n > 0){
            trib[1] = 1;
            if(n > 1){
                trib[2] = 1;
                if(n > 2){
                for(int i = 3; i <= n; i++)
                    trib[i] = trib[i-1] + trib[i-2] + trib[i-3];
                }
            }
        }
        return trib[n];
    }
}