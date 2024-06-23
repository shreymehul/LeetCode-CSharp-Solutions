// 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit

// Given an array of integers nums and an integer limit, return the size of the longest non-empty subarray such that the absolute difference between any two elements of this subarray is less than or equal to limit.

// Example 1:
// Input: nums = [8,2,4,7], limit = 4
// Output: 2 
// Explanation: All subarrays are: 
// [8] with maximum absolute diff |8-8| = 0 <= 4.
// [8,2] with maximum absolute diff |8-2| = 6 > 4. 
// [8,2,4] with maximum absolute diff |8-2| = 6 > 4.
// [8,2,4,7] with maximum absolute diff |8-2| = 6 > 4.
// [2] with maximum absolute diff |2-2| = 0 <= 4.
// [2,4] with maximum absolute diff |2-4| = 2 <= 4.
// [2,4,7] with maximum absolute diff |2-7| = 5 > 4.
// [4] with maximum absolute diff |4-4| = 0 <= 4.
// [4,7] with maximum absolute diff |4-7| = 3 <= 4.
// [7] with maximum absolute diff |7-7| = 0 <= 4. 
// Therefore, the size of the longest subarray is 2.
// Example 2:
// Input: nums = [10,1,2,4,7,2], limit = 5
// Output: 4 
// Explanation: The subarray [2,4,7,2] is the longest since the maximum absolute diff is |2-7| = 5 <= 5.
// Example 3:
// Input: nums = [4,2,2,2,4,4,2,2], limit = 0
// Output: 3

// Constraints:
// 1 <= nums.length <= 105
// 1 <= nums[i] <= 109
// 0 <= limit <= 109

public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        int start = 0;
        int maxLength = 0;
        
        LinkedList<int> minDeque = new LinkedList<int>();
        LinkedList<int> maxDeque = new LinkedList<int>();

        for (int end = 0; end < nums.Length; end++) {
            // Maintain the maxDeque: elements in decreasing order
            while (maxDeque.Count > 0 && maxDeque.Last.Value < nums[end]) {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(nums[end]);

            // Maintain the minDeque: elements in increasing order
            while (minDeque.Count > 0 && minDeque.Last.Value > nums[end]) {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(nums[end]);

            // Check if the current window is valid
            while (maxDeque.First.Value - minDeque.First.Value > limit) {
                if (maxDeque.First.Value == nums[start]) {
                    maxDeque.RemoveFirst();
                }
                if (minDeque.First.Value == nums[start]) {
                    minDeque.RemoveFirst();
                }
                start++;
            }

            // Update the maximum length
            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}

// LinkedList for Deques:
// We use LinkedList<int> directly to maintain the minimum and maximum values.
// These linked lists (minDeque and maxDeque) will store values in a way that allows efficient addition and removal from both ends.

// Maintaining Deques:
// For maxDeque, we remove elements from the back while the current element is greater than the elements at the back to maintain a decreasing order.
// For minDeque, we remove elements from the back while the current element is less than the elements at the back to maintain an increasing order.

// Validating the Window:
// If the difference between the maximum and minimum values in the current window exceeds the limit, we shrink the window from the start.
// This involves removing the element at the start from the deques if it is the front element of either deque.

// Max Length Calculation:
// We update maxLength with the size of the current valid window.

// Complexity:
// Time Complexity: O(n), where n is the length of the array. Each element is added and removed from the deques at most once.
// Space Complexity: O(n) in the worst case, for the deques.