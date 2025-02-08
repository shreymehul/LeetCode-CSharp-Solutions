// 1909. Remove One Element to Make the Array Strictly Increasing
// Given a 0-indexed integer array nums, return true if it can be made strictly increasing after removing exactly one element, 
// or false otherwise. If the array is already strictly increasing, return true.
// The array nums is strictly increasing if nums[i - 1] < nums[i] for each index (1 <= i < nums.length).

// Example 1:
// Input: nums = [1,2,10,5,7]
// Output: true
// Explanation: By removing 10 at index 2 from nums, it becomes [1,2,5,7].
// [1,2,5,7] is strictly increasing, so return true.

// Example 2:
// Input: nums = [2,3,1,2]
// Output: false
// Explanation:
// [3,1,2] is the result of removing the element at index 0.
// [2,1,2] is the result of removing the element at index 1.
// [2,3,2] is the result of removing the element at index 2.
// [2,3,1] is the result of removing the element at index 3.
// No resulting array is strictly increasing, so return false.

// Example 3:
// Input: nums = [1,1,1]
// Output: false
// Explanation: The result of removing any element is [1,1].
// [1,1] is not strictly increasing, so return false.

// Constraints:
// 2 <= nums.length <= 1000
// 1 <= nums[i] <= 1000
public class Solution {
    public bool CanBeIncreasing(int[] nums) {
        bool removedElement = false;

        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] <= nums[i - 1]) {
                // If an element has already been removed, return false
                if (removedElement) return false;

                removedElement = true; // first violation

                // Check if removing nums[i] or nums[i - 1] keeps the sequence increasing
                if (i > 1 && nums[i] <= nums[i - 2]) {
                    nums[i] = nums[i - 1]; // Remove current element by skipping its effect
                }
            }
        }

        return true;
    }
}


//Question Variation: remove a subarray to to make array stritly increasing. 
public class Solution {
    public bool CanBeIncreasing(int[] nums) {
        int n = nums.Length;
        if (n <= 2) return true;

        int start = -1, end = -1;

        // Find first decreasing point
        for (int i = 1; i < n; i++) {
            if (nums[i] <= nums[i - 1]) {
                start = i - 1;
                break;
            }
        }

        // No decreasing point found; already strictly increasing
        if (start == -1) return true;

        // Find last decreasing point
        for (int i = n - 2; i >= 0; i--) {
            if (nums[i] >= nums[i + 1]) {
                end = i + 1;
                break;
            }
        }

        // Check if removing subarray [start, end] makes it valid
        return IsValid(nums, start, end);
    }

    private bool IsValid(int[] nums, int start, int end) {
        int n = nums.Length;

        // Handle edge cases when removing prefix or suffix
        if (start == 0 || end == n - 1) return true;

        // Check if the array remains strictly increasing
        return nums[start - 1] < nums[end];
    }
}
