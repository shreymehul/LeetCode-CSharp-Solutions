// 560. Subarray Sum Equals K

// Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.

// A subarray is a contiguous non-empty sequence of elements within an array.

 

// Example 1:

// Input: nums = [1,1,1], k = 2
// Output: 2
// Example 2:

// Input: nums = [1,2,3], k = 3
// Output: 2c 

public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int[] preSum = new int[nums.Length];
        int count = 0;
        for(int i = 0; i < nums.Length; i++){
            preSum[i] = nums[i];
            if(i>0)
                preSum[i] += preSum[i-1];
            if(preSum[i] == k)
                count++;
        }
        for(int i = 0; i < preSum.Length-1; i++){
            for(int j = i + 1; j < preSum.Length; j++){
                if(preSum[j] - preSum[i] == k)
                    count++;
            }
        }
        return count;
    }
}