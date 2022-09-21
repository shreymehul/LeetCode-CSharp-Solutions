// 287. Find the Duplicate Number

// Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

// There is only one repeated number in nums, return this repeated number.

// You must solve the problem without modifying the array nums and uses only constant extra space.

 

// Example 1:

// Input: nums = [1,3,4,2,2]
// Output: 2


public class Solution {
    public int FindDuplicate(int[] nums) {
        int[] freq = new int[nums.Length];
        for(int i = 0;i<nums.Length;i++){
            freq[nums[i]]++;
        }
        for(int i = 0;i<freq.Length;i++){
            if(freq[i] >1)
                return i;
        }
        return 0;
    }
}