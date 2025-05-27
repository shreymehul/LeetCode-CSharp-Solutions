// 137. Single Number II

// Given an integer array nums where every element appears three times except for one, which appears exactly once. Find the single element and return it.

// You must implement a solution with a linear runtime complexity and use only constant extra space.

// Example 1:
// Input: nums = [2,2,3,2]
// Output: 3
// Example 2:
// Input: nums = [0,1,0,1,0,1,99]
// Output: 99

// Constraints:

// 1 <= nums.length <= 3 * 104
// -231 <= nums[i] <= 231 - 1
// Each element in nums appears exactly three times except for one element which appears once.

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int ones = 0; // Tracks the bits that have appeared once
        int twos = 0; // Tracks the bits that have appeared twice

        foreach (int num in nums)
        {
            ones = (ones ^ num) & ~twos;
            twos = (twos ^ num) & ~ones;
        }

        return ones;
    }
}

// Intuition
// The intuition behind the solution is to use bitwise manipulation to keep track of the bits that have appeared once and twice. By doing so, we can identify the single element that appears only once in the array.

// Approach
// The approach used in the solution is based on two bitmasks: ones and twos. The ones bitmask keeps track of the bits that have appeared once, and the twos bitmask keeps track of the bits that have appeared twice.
// For each number in the array, we update the bitmasks as follows:
// Update the ones bitmask: We perform the XOR operation between ones and the number to update the bits that have appeared once. Then, we clear the bits that also appear in the twos bitmask by using the bitwise AND operation with the negation of twos.
// Update the twos bitmask: We perform the XOR operation between twos and the number to update the bits that have appeared twice. Then, we clear the bits that also appear in the ones bitmask by using the bitwise AND operation with the negation of ones.
// At the end of the iteration, the ones bitmask will contain the bits of the single element that appears only once in the array, and we return its value as the result.
// Complexity
// Time complexity:
// The time complexity of the solution is O(n), where n is the length of the input array. This is because we iterate through the array once.

// Space complexity:
// The space complexity of the solution is O(1) because we only use two integer variables (ones and twos) to keep track of the bitmasks. The space usage does not depend on the size of the input array.