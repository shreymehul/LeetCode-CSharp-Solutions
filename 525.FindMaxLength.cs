// 525. Contiguous Array

// Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.
// Example 1:
// Input: nums = [0,1]
// Output: 2
// Explanation: [0, 1] is the longest contiguous subarray with an equal number of 0 and 1.
// Example 2:
// Input: nums = [0,1,0]
// Output: 2
// Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

// Constraints:
// 1 <= nums.length <= 105
// nums[i] is either 0 or 1.

public class Solution {
    public int FindMaxLength(int[] nums) {
        Dictionary<int,int> map = new();
        map[0] = -1;
        int zero = 0, one = 0, max = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == 0)
                zero++;
            else
                one++;
            int diff = zero - one;
            if(map.ContainsKey(diff))
                max = Math.Max(max, i - map[diff]);
            else
                map[diff] = i;
        }
        return max;
    }
}