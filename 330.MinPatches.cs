// 330. Patching Array
// Given a sorted integer array nums and an integer n, add/patch elements to the array such that any number in the range [1, n] inclusive can be formed by the sum of some elements in the array.
// Return the minimum number of patches required.

// Example 1:
// Input: nums = [1,3], n = 6
// Output: 1
// Explanation:
// Combinations of nums are [1], [3], [1,3], which form possible sums of: 1, 3, 4.
// Now if we add/patch 2 to nums, the combinations are: [1], [2], [3], [1,3], [2,3], [1,2,3].
// Possible sums are 1, 2, 3, 4, 5, 6, which now covers the range [1, 6].
// So we only need 1 patch.
// Example 2:
// Input: nums = [1,5,10], n = 20
// Output: 2
// Explanation: The two patches can be [2, 4].
// Example 3:
// Input: nums = [1,2,2], n = 5
// Output: 0

// Constraints:
// 1 <= nums.length <= 1000
// 1 <= nums[i] <= 104
// nums is sorted in ascending order.
// 1 <= n <= 231 - 1

public class Solution {
    public int MinPatches(int[] nums, int n) {
        long miss = 1;  // Represents the smallest number that cannot be formed with the current set
        int patches = 0; // Counter for the number of patches (numbers added)
        int i = 0;  // Index to traverse through the nums array

        // Loop until we can form all numbers from 1 to n
        while (miss <= n) {

            // If the current number in the array can be used to form 'miss' or less
            if (i < nums.Length && nums[i] <= miss) {
                miss += nums[i];  // Include nums[i] to form more numbers
                i++;  // Move to the next number in the array
            } else {
                // If nums[i] is too large or we have used all numbers in the array,
                // add a new number 'miss' to the set
                miss += miss;  // Double the range of numbers we can form
                patches++;  // Increment the patches counter
            }
        }
        
        return patches;  // Return the total number of patches added
    }
}


// Explanation:

// Variables Initialization:
// miss is initialized to 1. It represents the smallest number that we currently cannot form using the numbers in the array or the numbers we've added (patches).
// patches is a counter to keep track of how many numbers we've added to the array to be able to form the sequence up to n.
// i is used to traverse through the nums array.

// Main Loop:
// The loop continues as long as miss is less than or equal to n. This ensures we can form all numbers from 1 to n.

// Condition Check:
// if (i < nums.Length && nums[i] <= miss): If the current number in nums can be used to extend the range of numbers we can form, we add it to miss and move to the next number in the array by incrementing i.
// else: If the current number in nums is too large to be used or we have used all numbers in the array, we add miss itself as a patch to extend the range. This effectively doubles the range of numbers we can form. We also increment the patches counter.

// Return Statement:
// After the loop completes, we return the total number of patches needed to ensure we can form all numbers from 1 to n.

// This code efficiently determines the minimum number of patches required to ensure the sequence from 1 to n can be formed using the given array and any additional numbers as patches.