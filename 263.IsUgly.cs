// 263. Ugly Number
// An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
// Given an integer n, return true if n is an ugly number.

public class Solution
{
    public bool IsUgly(int n)
    {
        if (n == 0)
            return false;
        int temp = n;
        while (temp % 2 == 0)
        {
            temp /= 2;
        }
        while (temp % 3 == 0)
        {
            temp /= 3;
        }
        while (temp % 5 == 0)
        {
            temp /= 5;
        }
        if (temp == 1)
            return true;
        return false;
    }
}