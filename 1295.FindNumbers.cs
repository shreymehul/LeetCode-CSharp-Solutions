//1295. Find Numbers with Even Number of Digits
//Given an array nums of integers, return how many of them contain an even number of digits.
public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = nums[i];
            int k = 0;
            while (temp > 0)
            {
                temp /= 10;
                k++;
            }
            if (k % 2 == 0)
                count++;
        }
        return count;
    }
}

