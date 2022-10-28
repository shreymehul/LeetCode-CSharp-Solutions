// 34. Find First and Last Position of Element in Sorted Array

// Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

// If target is not found in the array, return [-1, -1].

// You must write an algorithm with O(log n) runtime complexity.
// Example 1:

// Input: nums = [5,7,7,8,8,10], target = 8
// Output: [3,4]
// Example 2:

// Input: nums = [5,7,7,8,8,10], target = 6
// Output: [-1,-1]
// Example 3:

// Input: nums = [], target = 0
// Output: [-1,-1]

public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] res = new int[2];
        res[0] = FirstBinarySearch(nums, 0, nums.Length-1, target);
        res[1] = LastBinarySearch(nums, 0, nums.Length-1, target);
        return res;
    }
    public int FirstBinarySearch(int[] nums, int left, int right, int target){
        if(left > right)
            return -1;
        int mid = (right - left)/2 + left;
        if(nums[mid] == target && (mid == 0 || nums[mid] != nums[mid-1]))
            return mid;
        if(nums[mid] >= target)
            return FirstBinarySearch(nums, left, mid-1, target);
        return FirstBinarySearch(nums, mid+1, right, target);
    }
    
    public int LastBinarySearch(int[] nums, int left, int right, int target){
        if(left > right)
            return -1;
        int mid = (right - left)/2 + left;
        if(nums[mid] == target && (mid == nums.Length-1 || nums[mid] != nums[mid+1]))
            return mid;
        if(nums[mid] <= target)
            return LastBinarySearch(nums, mid+1, right, target);
        return LastBinarySearch(nums, left, mid-1, target);
    }
}