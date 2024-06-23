// 2302. Count Subarrays With Score Less Than K
// The score of an array is defined as the product of its sum and its length.
// For example, the score of [1, 2, 3, 4, 5] is (1 + 2 + 3 + 4 + 5) * 5 = 75.
// Given a positive integer array nums and an integer k, return the number of non-empty subarrays of nums whose score is strictly less than k.
// A subarray is a contiguous sequence of elements within an array.

// Example 1:
// Input: nums = [2,1,4,3,5], k = 10
// Output: 6
// Explanation:
// The 6 subarrays having scores less than 10 are:
// - [2] with score 2 * 1 = 2.
// - [1] with score 1 * 1 = 1.
// - [4] with score 4 * 1 = 4.
// - [3] with score 3 * 1 = 3. 
// - [5] with score 5 * 1 = 5.
// - [2,1] with score (2 + 1) * 2 = 6.
// Note that subarrays such as [1,4] and [4,3,5] are not considered because their scores are 10 and 36 respectively, while we need scores strictly less than 10.

// Example 2:
// Input: nums = [1,1,1], k = 5
// Output: 5
// Explanation:
// Every subarray except [1,1,1] has a score less than 5.
// [1,1,1] has a score (1 + 1 + 1) * 3 = 9, which is greater than 5.
// Thus, there are 5 subarrays having scores less than 5.

// Constraints:
// 1 <= nums.length <= 105
// 1 <= nums[i] <= 105
// 1 <= k <= 1015

public class Solution {
    public long CountSubarrays(int[] nums, long k) {
        // n is the length of the input array
        int n = nums.Length;
        // Variable to keep track of the count of subarrays
        long count = 0;
        // Variable to keep the current sum of the window
        long currentSum = 0;
        // Start pointer for the sliding window
        int start = 0;
        
        // Iterate through each element in the array with the end pointer
        for (int end = 0; end < n; end++) {
            // Add the current element to the currentSum
            currentSum += nums[end];
            
            // While the score of the current window is not less than k
            while (currentSum * (end - start + 1) >= k) {
                // Remove the start element from the currentSum and move the start pointer to the right
                currentSum -= nums[start];
                start++;
            }
            
            // Add the number of valid subarrays ending at the current end pointer
            count += (end - start + 1);
        }
        
        // Return the total count of valid subarrays
        return count;
    }
}

/*
Complexity Analysis:
- Time Complexity: O(n)
Each element is added and removed from the currentSum at most once, resulting in a linear time complexity.
- Space Complexity: O(1)
We use a few extra variables (currentSum, count, start) that do not depend on the input size, resulting in constant space complexity.


Sliding Window Approach:
We use a sliding window to keep track of the current subarray sum.
The start pointer moves right whenever the score condition currentSum * (end - start + 1) >= k is not met.

Efficiency:
The sliding window ensures that each element is processed in linear time, improving efficiency from the original nested loop approach.

Loop Indices:
Using int for indices since array indices are integers.

*/