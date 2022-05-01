// 9. Palindrome Number
// Given an integer x, return true if x is palindrome integer.
// An integer is a palindrome when it reads the same backward as forward.
// For example, 121 is a palindrome while 123 is not.
public class Solution
{
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