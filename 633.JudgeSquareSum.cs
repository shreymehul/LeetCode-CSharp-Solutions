// 633. Sum of Square Numbers
// Given a non-negative integer c, decide whether there're two integers a and b such that a2 + b2 = c.

// Example 1:
// Input: c = 5
// Output: true
// Explanation: 1 * 1 + 2 * 2 = 5
// Example 2:
// Input: c = 3
// Output: false

// Constraints:
// 0 <= c <= 231 - 1


//Approch 1 Fermat's theorem
public class Solution {
    public bool JudgeSquareSum(int c) {
        if (c < 0) return false; // Negative numbers cannot be expressed as the sum of two squares
        
        int originalC = c; // Store the original value of c
        
        for(int divisor = 2; divisor * divisor <= c; divisor++) {
            if (c % divisor == 0) {
                int exponentCount = 0;
                while (c % divisor == 0) {
                    exponentCount++;
                    c /= divisor;
                }
                if (divisor % 4 == 3 && exponentCount % 2 != 0) {
                    return false;
                }
            }
        }
        
        // If the remaining c is a prime number of the form 4k+3, it should appear an even number of times
        // If after factorization, c is still greater than 1 and of the form 4k+3, it means it's a prime factor itself
        return c % 4 != 3;
    }
}

// The code provided is a solution to check if a given number c can be expressed as the sum of two squares. 
// It implements Fermat's theorem on sums of two squares, which states that a number c can be expressed as the sum of two 
// squares if every prime factor of the form 4k+3 in its prime factorization appears with an even exponent.

//Approch 2 Two Sum
public class Solution {
    public bool JudgeSquareSum(int c) {
        int left = 0;
        int right = (int)Math.Sqrt(c);
        
        while (left <= right) {
            long sum = (long)left * left + (long)right * right;
            if (sum == c) {
                return true;
            } else if (sum < c) {
                left++;
            } else {
                right--;
            }
        }
        
        return false;
    }
}