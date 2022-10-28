// 33. Search in Rotated Sorted Array

// There is an integer array nums sorted in ascending order (with distinct values).

// Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

// Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

// You must write an algorithm with O(log n) runtime complexity.

// Example 1:

// Input: nums = [4,5,6,7,0,1,2], target = 0
// Output: 4
// Example 2:

// Input: nums = [4,5,6,7,0,1,2], target = 3
// Output: -1
// Example 3:

// Input: nums = [1], target = 0
// Output: -1

public class Solution {
    public int Search(int[] nums, int target) {
        return BinarySearch(nums, target, 0, nums.Length-1);
    }
    
    public int BinarySearch(int[] nums, int target, int left, int right){
        if(left > right)
            return -1;
        int mid = (right - left)/2 +left;
        if(nums[mid] == target)
            return mid;
        if(nums[mid] >= nums[left]){
            if(nums[left] <= target && target < nums[mid])
                return BinarySearch(nums, target, left, mid-1);
            return BinarySearch(nums, target, mid+1, right);
        }
        if((nums[mid] < target && target <= nums[right]) )
            return BinarySearch(nums, target, mid+1, right);
        return BinarySearch(nums, target, left, mid-1);
    }
}