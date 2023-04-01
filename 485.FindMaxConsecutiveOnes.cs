//485. Max Consecutive Ones
//Given a binary array nums, return the maximum number of consecutive 1's in the array.

public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int max, temp;
        max = temp = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                temp = 0;
            }
            else
                temp++;
            if (max < temp)
                max = temp;
        }
        return max;
    }
}

public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int max = 0, lmax = 0;
        foreach(int num in nums){
            if(num == 0){
                max = Math.Max(max,lmax);
                lmax = 0;
            }
            else
                lmax++;
        }
        return Math.Max(max,lmax);
    }
}