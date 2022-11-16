// 204. Count Primes

// Given an integer n, return the number of prime numbers that are strictly less than n.
// Example 1:
// Input: n = 10
// Output: 4
// Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
// Example 2:
// Input: n = 0
// Output: 0
// Example 3:
// Input: n = 1
// Output: 0

public class Solution {
    public int CountPrimes(int n) {
        bool[] NotPrime = new bool[n];
        int count = 0;
        for (int i = 2; i < n; i++)
        {
            if(!NotPrime[i]){
                count++;
                int j = 2;
                while (i * j < n)
                {
                    NotPrime[i*j] = true;
                    j++;
                }
            }
        }
        return count;
    }
}