// 264. Ugly Number II
// An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
// Given an integer n, return the nth ugly number.
// Example 1:
// Input: n = 10
// Output: 12
// Explanation: [1, 2, 3, 4, 5, 6, 8, 9, 10, 12] is the sequence of the first 10 ugly numbers.
// Example 2:
// Input: n = 1
// Output: 1
// Explanation: 1 has no prime factors, therefore all of its prime factors are limited to 2, 3, and 5.

public class Solution {
    public int NthUglyNumber(int n) {
        if(n==1)
            return 1;
        
        int[] ugly = new int[n];
        int i2=0,i3=0,i5=0;
        ugly[0] = 1;
        for(int i = 1; i < n; i++){
            ugly[i] = Math.Min(2*ugly[i2],Math.Min(3*ugly[i3],5*ugly[i5]));
            if(ugly[i] == 2*ugly[i2])
                i2++;
            if(ugly[i] == 3*ugly[i3])
                i3++;
            if(ugly[i] == 5*ugly[i5])
                i5++;
        }
        return ugly[n-1];
    }
}