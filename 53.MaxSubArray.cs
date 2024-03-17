// 53. Maximum Subarray

// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and 
// return its sum.

// A subarray is a contiguous part of an array.
// Example 1:

// Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
// Output: 6
// Explanation: [4,-1,2,1] has the largest sum = 6.
// Example 2:

// Input: nums = [1]
// Output: 1
// Example 3:

// Input: nums = [5,4,-1,7,8]
// Output: 23

//kadens algo
public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = Int32.MinValue;
        int maxTillHere = 0;
        
        for(int i = 0; i < nums.Length; i++){
            maxTillHere += nums[i];
            max = Math.Max(maxTillHere, max);
            maxTillHere = Math.Max(maxTillHere, 0); //Add untill number is still positive
        }
        return max;
    }
}


public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = nums[0], sum = nums[0];
        //Intuition: Add the current number to the sum till its positive and upudate the maximum sum
        for(int i = 1; i < nums.Length; i++){
            //If the sum is negative, reset it to 0
            if(sum < 0)
                sum = 0;
            //Add the current number to the sum
            sum += nums[i];
            //Update the maximum sum
            max = Math.Max(max, sum);
        }
        return max;
    }
}

//prefixsum array
public class Solution {
    public int MaxSubArray(int[] nums) {
        int[] prefixsum = new int[nums.Length + 1];
        prefixsum[0] = 0;
        
        for(int i = 0; i < nums.Length; i++){
            
           prefixsum[i+1] = prefixsum[i] + nums[i]; 
        }
        
        int max = nums[0];
        for(int i = 1; i <= nums.Length; i++ ){
            int s = 0;
            for(int j = i; j <= nums.Length; j++){
                s = prefixsum[j] - prefixsum[i-1]; // sum from i to j position
                max = max > s ? max : s;
            }
        }
        return max;
    }
}