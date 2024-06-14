// 945. Minimum Increment to Make Array Unique
// You are given an integer array nums. In one move, you can pick an index i where 0 <= i < nums.length and increment nums[i] by 1.
// Return the minimum number of moves to make every value in nums unique.

// The test cases are generated so that the answer fits in a 32-bit integer.

// Example 1:
// Input: nums = [1,2,2]
// Output: 1
// Explanation: After 1 move, the array could be [1, 2, 3].
// Example 2:
// Input: nums = [3,2,1,2,1,7]
// Output: 6
// Explanation: After 6 moves, the array could be [3, 4, 1, 2, 5, 7].
// It can be shown with 5 or less moves that it is impossible for the array to have all unique values.

// Constraints:
// 1 <= nums.length <= 105
// 0 <= nums[i] <= 105


// Explanation
// Sorting the Array: The array is sorted to make it easier to handle duplicates. Once sorted, any duplicates will be next to each other.
// Initialize Result: The result variable is initialized to keep track of the total number of increments needed.
// Traverse the Array: The loop starts from the second element because the first element does not need to be compared.
// Check for Duplicates: If the current element is less than or equal to the previous element, it means we have a duplicate or an element that needs to be incremented to ensure uniqueness.
// Calculate Increment: The required increment to make the current element unique is calculated as the difference between the previous element plus one and the current element.
// Increment the Element: The current element is incremented by the calculated amount.
// Update Result: The calculated increment is added to the result.
// Return Result: Finally, the total number of increments needed to make all elements unique is returned.

// Complexity
// Time complexity: O(nlogn)
// Space complexity: O(1)

public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        // Sort the array to handle duplicates easily
        Array.Sort(nums);
        
        int result = 0; // Initialize the result to store the number of increments
        
        // Traverse the array starting from the second element
        for (int i = 1; i < nums.Length; i++) {
            // If the current element is not greater than the previous element
            if (nums[i] <= nums[i - 1]) {
                // Calculate the increment needed to make the current element unique
                int increment = nums[i - 1] + 1 - nums[i];
                // Increment the current element
                nums[i] += increment;
                // Add the increment to the result
                result += increment;
            }
        }
        
        // Return the total number of increments needed
        return result;
    }
}