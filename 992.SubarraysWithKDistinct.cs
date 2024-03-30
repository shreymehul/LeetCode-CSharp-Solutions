// 992. Subarrays with K Different Integers
// Given an integer array nums and an integer k, return the number of good subarrays of nums.

// A good array is an array where the number of different integers in that array is exactly k.

// For example, [1,2,3,1,2] has 3 different integers: 1, 2, and 3.
// A subarray is a contiguous part of an array.

// Example 1:
// Input: nums = [1,2,1,2,3], k = 2
// Output: 7
// Explanation: Subarrays formed with exactly 2 different integers: [1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2], [1,2,1,2]
// Example 2:
// Input: nums = [1,2,1,3,4], k = 3
// Output: 3
// Explanation: Subarrays formed with exactly 3 different integers: [1,2,1,3], [2,1,3], [1,3,4].

// Constraints:
// 1 <= nums.length <= 2 * 104
// 1 <= nums[i], k <= nums.length

public class Solution {
    public int SubarraysWithKDistinct(int[] nums, int k) {
        // Count Subarrays with 1 to k distinct element
        // Count Subarrays with 1 to k - 1 distinct element
        // Subtract the two counts to get the count of subarrays with exactly k distinct element
        return AtMostKDistinct(nums, k) - AtMostKDistinct(nums, k - 1);
    }
    // Count the number of subarrays with at most k distinct element i.e. the number of subarrays with 1 to k distinct element
    private int AtMostKDistinct(int[] nums, int k) {
        int count = 0;
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        int left = 0;
        // Sliding window
        for (int right = 0; right < nums.Length; right++) {
            int num = nums[right];
            if (!frequencyMap.ContainsKey(num))
                frequencyMap[num] = 0;
            frequencyMap[num]++;
            
            // If the number of distinct element is greater than k, move the left pointer to the right 
            // until the number of distinct element is less than or equal to k
            while (frequencyMap.Count > k) {
                frequencyMap[nums[left]]--;
                if (frequencyMap[nums[left]] == 0)
                    frequencyMap.Remove(nums[left]);
                left++;
            }
            // Number of subarrays with at most k distinct element is equal to the number of 
            // subarrays from the left pointer to the right pointer
            count += right - left + 1;
        }
        
        return count;
    }
}