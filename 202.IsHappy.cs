// 202. Happy Number
// Write an algorithm to determine if a number n is happy.
// A happy number is a number defined by the following process:
// Starting with any positive integer, replace the number by the sum of the squares of its digits.
// Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
// Those numbers for which this process ends in 1 are happy.
// Return true if n is a happy number, and false if not.
public class Solution
{
    public bool IsHappy(int n)
    {
        if (n == 1)
            return true;
        else if (n <= 0)
            return false;
        List<int> watch = new List<int>();
        while (true)
        {
            
            int temp = n;
            int sqSum = 0;
            while (temp > 0)
            {
                int mod = temp % 10;
                sqSum += (mod * mod);
                temp /= 10;
            }
            if (sqSum == 1)
                break;
            else
            {
                if (watch.Contains(sqSum))
                {
                    return false;
                }
                else
                    watch.Add(sqSum);
            }
                
            n = sqSum;
        }
        return true;

    }
}