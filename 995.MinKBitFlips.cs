
// 995. Minimum Number of K Consecutive Bit Flips
// You are given a binary array nums and an integer k.
// A k-bit flip is choosing a subarray of length k from nums and simultaneously changing every 0 in the subarray to 1, and every 1 in the subarray to 0.
// Return the minimum number of k-bit flips required so that there is no 0 in the array. If it is not possible, return -1.
// A subarray is a contiguous part of an array.

// Example 1:
// Input: nums = [0,1,0], k = 1
// Output: 2
// Explanation: Flip nums[0], then flip nums[2].
// Example 2:
// Input: nums = [1,1,0], k = 2
// Output: -1
// Explanation: No matter how we flip subarrays of size 2, we cannot make the array become [1,1,1].
// Example 3:
// Input: nums = [0,0,0,1,0,1,1,0], k = 3
// Output: 3
// Explanation: 
// Flip nums[0],nums[1],nums[2]: nums becomes [1,1,1,1,0,1,1,0]
// Flip nums[4],nums[5],nums[6]: nums becomes [1,1,1,1,1,0,0,0]
// Flip nums[5],nums[6],nums[7]: nums becomes [1,1,1,1,1,1,1,1]

// Constraints:
// 1 <= nums.length <= 105
// 1 <= k <= nums.length

public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
       int currentFlips = 0; // Tracks the current number of flips
        int totalFlips = 0; // Tracks the total number of flips

        for (int i = 0; i < nums.Length; ++i) {
            // If the window slides out of the range and the leftmost element is
            // marked as flipped (2), decrement currentFlips
            if (i >= k && nums[i - k] == 2) {
                currentFlips--;
            }

            // Check if the current bit needs to be flipped
            if ((currentFlips % 2) == nums[i]) {
                // If flipping would exceed array bounds, return -1
                if (i + k > nums.Length) {
                    return -1;
                }
                // Mark the current bit as flipped
                nums[i] = 2;
                currentFlips++;
                totalFlips++;
            }
        }

        return totalFlips; 
    }
}