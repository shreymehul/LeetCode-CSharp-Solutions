// 238. Product of Array Except Self

// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of
// nums except nums[i].

// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
// You must write an algorithm that runs in O(n) time and without using the division operation.

// Example 1:
// Input: nums = [1,2,3,4]
// Output: [24,12,8,6]
// Example 2:
// Input: nums = [-1,1,0,-3,3]
// Output: [0,0,9,0,0]

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        int product=1;
        int noZero = 0;
        for(int i =0;i<nums.Length;i++){
            if(nums[i] != 0)
                product *= nums[i];
            else
                noZero++;
        }
        for(int i =0;i<nums.Length;i++){
            if((nums[i] == 0 && noZero > 1) || (nums[i] != 0 && noZero > 0))
                result[i] = 0;
            else if (nums[i] == 0)
                result[i] = product;
            else
                result[i] = product/nums[i];
        }
        return result;
    }
}