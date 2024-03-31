// 2444. Count Subarrays With Fixed Bounds
// You are given an integer array nums and two integers minK and maxK.

// A fixed-bound subarray of nums is a subarray that satisfies the following conditions:

// The minimum value in the subarray is equal to minK.
// The maximum value in the subarray is equal to maxK.
// Return the number of fixed-bound subarrays.
// A subarray is a contiguous part of an array.

// Example 1:
// Input: nums = [1,3,5,2,7,5], minK = 1, maxK = 5
// Output: 2
// Explanation: The fixed-bound subarrays are [1,3,5] and [1,3,5,2].
// Example 2:
// Input: nums = [1,1,1,1], minK = 1, maxK = 1
// Output: 10
// Explanation: Every subarray of nums is a fixed-bound subarray. There are 10 possible subarrays.

// Constraints:
// 2 <= nums.length <= 105
// 1 <= nums[i], minK, maxK <= 106

public class Solution {
    //intuition: we need to find the number of subarrays that have minK and maxK as the minimum and maximum values respectively.
    //we can keep track of the last index of minK and maxK in the array and the last index of a value that is not in the range of minK and maxK.
    //if we find a value that is not in the range of minK and maxK, we update the last index of the value to the current index.
    //if we find a value that is equal to minK, we update the last index of minK to the current index.
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        long result = 0;
        long bad_idx, min_idx, max_idx;
        bad_idx = min_idx = max_idx = -1;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] < minK || nums[i] > maxK)
                bad_idx = i;
            if(nums[i] == minK)
                min_idx = i;
            if(nums[i] == maxK)
                max_idx = i;
            //we add the number of subarrays that have minK and maxK as the minimum and maximum values respectively.
            //its the minimum of the last index of minK and maxK minus the last index of a value that is not in the range of minK and maxK.
            result += Math.Max(0, Math.Min(min_idx, max_idx) - bad_idx);
        }
        return result;
    }
}