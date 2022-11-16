// 367. Valid Perfect Square
// Given a positive integer num, write a function which returns True if num is a perfect square else False.
// Follow up: Do not use any built-in library function such as sqrt.
// Example 1:
// Input: num = 16
// Output: true
// Example 2:
// Input: num = 14
// Output: false

public class Solution {
    public bool IsPerfectSquare(int num) {
        if (num < 3)
        {
            if (num == 1)
                return true;
            return false;
        }
        int low = 2, high = num / 2;
        while (low <= high)
        {
            int mid = (high - low) / 2 + low;
            long midSq = (long)mid * (long)mid;
            if (midSq == num)
                return true;
            if (midSq > num)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return false;
    }
}