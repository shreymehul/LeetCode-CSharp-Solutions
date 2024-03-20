// 9. Palindrome Number
// Given an integer x, return true if x is palindrome integer.
// An integer is a palindrome when it reads the same backward as forward.
// For example, 121 is a palindrome while 123 is not.

// Example 1:
// Input: x = 121
// Output: true
// Explanation: 121 reads as 121 from left to right and from right to left.
// Example 2:
// Input: x = -121
// Output: false
// Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
// Example 3:
// Input: x = 10
// Output: false
// Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

// Constraints:
// -231 <= x <= 231 - 1
public class Solution
{
    //intution: reverse the number and compare it with the original number.
    public bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;
        if (x == 0 || x <= 9)
            return true;
        int rev = 0, num;
        num = x;
        while (num > 0)
        {
            rev = rev * 10 + num % 10;
            num = num / 10;
        }
        if (rev == x)
            return true;
        return false;
    }
}