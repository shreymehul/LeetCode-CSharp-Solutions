// 154. Find Minimum in Rotated Sorted Array II
// Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,4,4,5,6,7] might become:
// [4,5,6,7,0,1,4] if it was rotated 4 times.
// [0,1,4,4,5,6,7] if it was rotated 7 times.
// Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
// Given the sorted rotated array nums that may contain duplicates, return the minimum element of this array.
// You must decrease the overall operation steps as much as possible.
// Example 1:
// Input: nums = [1,3,5]
// Output: 1
// Example 2:
// Input: nums = [2,2,2,0,1]
// Output: 0

public class Solution {
    public int FindMin(int[] nums) {
        Array.Sort(nums);
        return nums[0];
    }
}

// nums[lo] <= nums[mi] <= nums[hi], min is nums[lo]
// nums[lo] > nums[mi] <= nums[hi], (lo, mi] is not sorted, min is inside
// nums[lo] <= nums[mi] > nums[hi], (mi, hi] is not sorted, min is inside
// nums[lo] > nums[mi] > nums[hi], impossible

public int FindMin(int[] nums) {
        int left = 0,
            right = nums.Length-1;
        while(left < right){
            int mid = (right - left)/2 + left;
            if(nums[mid] > nums[right])
                left = mid + 1;
            else if (nums[mid] < nums[left])
                right = mid;
            else{
                right--;
            }
        }
        return nums[left];
    }