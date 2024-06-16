// 75. Sort Colors
// Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the 
// same color are adjacent, with the colors in the order red, white, and blue.

// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

// You must solve this problem without using the library's sort function.

// Example 1:
// Input: nums = [2,0,2,1,1,0]
// Output: [0,0,1,1,2,2]
// Example 2:
// Input: nums = [2,0,1]
// Output: [0,1,2]

// Constraints:

// n == nums.length
// 1 <= n <= 300
// nums[i] is either 0, 1, or 2.

public class Solution {
    public void SortColors(int[] nums) {
        int zeros = 0, ones = 0;
        for(int i = 0; i < nums.Length; i++){
            //Count the number of 0s and 1s
            if(nums[i] == 0)
                zeros++;
            else if (nums[i] == 1)
                ones++;
        }
        for(int i = 0; i < nums.Length; i++){
            //Fill the array with the counted 0s and 1s
            if(i < zeros)
                nums[i] = 0;
            else if (i < zeros + ones)
                nums[i] = 1;
            else
                nums[i] = 2;
        }
    }
}

public class Solution {
    public void SortColors(int[] nums) {
        int red = 0, white = 0, blue = 0;
        foreach(var num in nums){
            if(num == 0)
                red++;
            else if(num == 1)
                white++;
            else
                blue++;
        }
        int i = 0;
        while(red > 0){
            nums[i++] = 0;
            red--;
        }
        while(white > 0){
            nums[i++] = 1;
            white--;
        }
        while(blue > 0){
            nums[i++] = 2;
            blue--;
        }
    }
}

//Dutch National Flag
public class Solution {
    public void SortColors(int[] nums) {
        // Initialize pointers
        int low = 0;  // Pointer for the next position of 0
        int mid = 0;  // Pointer for the current element
        int high = nums.Length - 1;  // Pointer for the next position of 2

        // Iterate through the array
        while (mid <= high) {
            if (nums[mid] == 0) {
                // Swap the current element with the element at low pointer
                // Move both low and mid pointers forward
                (nums[mid], nums[low]) = (nums[low], nums[mid]);
                low++;
                mid++;
            }
            else if (nums[mid] == 2) {
                // Swap the current element with the element at high pointer
                // Move the high pointer backward
                // Do not move mid pointer forward as the element swapped to mid needs to be checked
                (nums[mid], nums[high]) = (nums[high], nums[mid]);
                high--;
            }
            else {
                // If the element is 1, just move the mid pointer forward
                mid++;
            }
        }
    }
}

// Detailed Explanation:
// Initialization:

// low is initialized to 0. It keeps track of where the next 0 should go.
// mid is initialized to 0. It is the current element being examined.
// high is initialized to the last index of the array. It keeps track of where the next 2 should go.
// Loop Condition:

// The loop runs while mid is less than or equal to high. This ensures that all elements are processed.
// Swapping:

// If nums[mid] is 0:
// Swap nums[mid] with nums[low] to move the 0 to its correct position.
// Increment both low and mid because the swapped element at mid is already processed.
// If nums[mid] is 2:
// Swap nums[mid] with nums[high] to move the 2 to its correct position.
// Decrement high because the swapped element at high is not yet processed, so we need to check the element now at mid again.
// If nums[mid] is 1:
// Simply increment mid because 1s are already in their correct positions in the middle.
// This approach ensures that all 0s are at the beginning, all 1s are in the middle, and all 2s are at the end of the array, sorting the array in a single pass with O(n) time complexity and O(1) space complexity.
