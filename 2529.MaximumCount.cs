// 2529. Maximum Count of Positive Integer and Negative Integer
// Given an array nums sorted in non-decreasing order, return the maximum between the number of positive integers and the number of negative integers.
// In other words, if the number of positive integers in nums is pos and the number of negative integers is neg, then return the maximum of pos and neg.
// Note that 0 is neither positive nor negative.
// Example 1:

// Input: nums = [-2,-1,-1,1,2,3]
// Output: 3
// Explanation: There are 3 positive integers and 3 negative integers. The maximum count among them is 3.
// Example 2:

// Input: nums = [-3,-2,-1,0,0,1,2]
// Output: 3
// Explanation: There are 2 positive integers and 3 negative integers. The maximum count among them is 3.
// Example 3:

// Input: nums = [5,20,66,1314]
// Output: 4
// Explanation: There are 4 positive integers and 0 negative integers. The maximum count among them is 4.

//Linear Search
public class Solution {
    public int MaximumCount(int[] nums) {
        int pos = 0, neg = 0;
        foreach(int num in nums){
            if(num < 0) neg++;
            if(num > 0) pos++;
        } 
        return Math.Max(neg,pos);
    }
}

//Binary Search
public class Solution {
    public int MaximumCount(int[] nums) {
        int pos = 0, neg = 0;
        pos = nums.Length - FindFirstPos(nums);
        pos = pos > nums.Length ? 0 : pos; 
        neg = FindLastNeg(nums) + 1;
        return Math.Max(neg,pos);
    }
    public int FindLastNeg(int[] nums){
        int left, right, mid;
        left = 0;
        right = nums.Length-1;
        while(left <= right){
            mid = left + (right-left)/2;
            if(nums[mid] < 0 && 
            ((nums.Length > mid + 1 && nums[mid + 1] >= 0)
            || nums.Length == mid + 1)){
                return mid;
            }
            else if(nums[mid] < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
    public int FindFirstPos(int[] nums){
        int left, right, mid;
        left = 0;
        right = nums.Length-1;
        while(left <= right){
            mid = left + (right-left)/2;
            if(nums[mid] > 0 && 
            ((mid > 0 && nums[mid - 1] <= 0)
            || mid == 0)){
                return mid;
            }
            else if(nums[mid] <= 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}