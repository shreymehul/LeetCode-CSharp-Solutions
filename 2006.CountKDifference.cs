// 2006. Count Number of Pairs With Absolute Difference K

// Given an integer array nums and an integer k, return the number of pairs (i, j) where i < j such that |nums[i] - nums[j]| == k.

// The value of |x| is defined as:

// x if x >= 0.
// -x if x < 0.

// Example 1:

// Input: nums = [1,2,2,1], k = 1
// Output: 4
// Explanation: The pairs with an absolute difference of 1 are:
// - [1,2,2,1]
// - [1,2,2,1]
// - [1,2,2,1]
// - [1,2,2,1]
// Example 2:

// Input: nums = [1,3], k = 3
// Output: 0
// Explanation: There are no pairs with an absolute difference of 3.
// Example 3:

// Input: nums = [3,2,1,5,4], k = 2
// Output: 3
// Explanation: The pairs with an absolute difference of 2 are:
// - [3,2,1,5,4]
// - [3,2,1,5,4]
// - [3,2,1,5,4]

public class Solution {
    public int CountKDifference(int[] nums, int k) {
        int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
            }
            int[] freq = new int[max + 1];
            foreach (int num in nums)
                freq[num]++;
            int count = 0;
            for (int i = 0; i < freq.Length - k; i++)
            {
                if (k == 0 && freq[i] > 1)
                {
                    count += freq[i] - 1;
                }
                else if (k !=0 && freq[i] > 0 && freq[i + k] > 0){
                    count += freq[i] * freq[i + k];
                }
            }
            return count;
    }
}