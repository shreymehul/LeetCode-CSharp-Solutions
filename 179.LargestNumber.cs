// 179. Largest Number
// Given a list of non-negative integers nums, arrange them such that they form the largest number and return it.

// Since the result may be very large, so you need to return a string instead of an integer.

// Example 1:
// Input: nums = [10,2]
// Output: "210"
// Example 2:
// Input: nums = [3,30,34,5,9]
// Output: "9534330"

// Constraints:
// 1 <= nums.length <= 100
// 0 <= nums[i] <= 109

public class Solution {
    public string LargestNumber(int[] nums) {
        // Create a custom comparer
        Array.Sort(nums, (a, b) => 
        {
            //10, 2
            string order1 = a.ToString() + b.ToString(); //102
            string order2 = b.ToString() + a.ToString(); //210
            return order2.CompareTo(order1);
        });

        // If the largest number is 0, return "0"
        if (nums[0] == 0) {
            return "0";
        }

        // Concatenate numbers to form the largest number
        return string.Join("", nums);
    }
}