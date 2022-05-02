// 136. Single Number
// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
// You must implement a solution with a linear runtime complexity and use only constant extra space.

public class Solution {
    public int SingleNumber(int[] nums) {
        
        int result = nums[0];
        for(int i = 1; i< nums.Length; i++)
            result ^= nums[i];
        return result;
    }
}