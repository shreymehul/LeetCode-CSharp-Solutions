// 503. Next Greater Element II
// Given a circular integer array nums (i.e., the next element of nums[nums.length - 1] is nums[0]), return the next greater number for every element in nums.
// The next greater number of a number x is the first greater number to its traversing-order next in the array, which means you could search circularly to find its next greater number. If it doesn't exist, return -1 for this number.

// Example 1:
// Input: nums = [1,2,1]
// Output: [2,-1,2]
// Explanation: The first 1's next greater number is 2; 
// The number 2 can't find next greater number. 
// The second 1's next greater number needs to search circularly, which is also 2.
// Example 2:
// Input: nums = [1,2,3,4,3]
// Output: [2,3,4,-1,4]

// Constraints:
// 1 <= nums.length <= 104
// -109 <= nums[i] <= 109

public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];
        Stack<int> st = new();

        // Initialize the result array with -1
        for (int i = 0; i < n; i++) {
            result[i] = -1;
        }

        // Process each element twice to handle the circular aspect
        for (int i = 2 * n - 1; i >= 0; i--) {
            while (st.Any() && nums[st.Peek()] <= nums[i % n]) {
                st.Pop();
            }
            if (st.Any()) {
                result[i % n] = nums[st.Peek()];
            }
            st.Push(i % n);
        }

        return result;
    }
}
