// 16. 3Sum Closest

// Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest 
// to target.
// Return the sum of the three integers.
// You may assume that each input would have exactly one solution.

// Example 1:
// Input: nums = [-1,2,1,-4], target = 1
// Output: 2
// Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
// Example 2:
// Input: nums = [0,0,0], target = 1
// Output: 0
// Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).

// Constraints:
// 3 <= nums.length <= 500
// -1000 <= nums[i] <= 1000
// -104 <= target <= 104

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int res = Int32.MaxValue;
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int j = i + 1, k = nums.Length - 1;
            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];
                if (Math.Abs(target - sum) < Math.Abs(target - res))
                    res = sum;
                if (target < sum)
                    k--;
                else
                    j++;
            }
        }
        return res;
    }
}


public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums); // Sort to use two-pointer technique
        int closest = nums[0] + nums[1] + nums[2]; // Initialize with first possible sum

        for (int i = 0; i < nums.Length - 2; i++) {
            // Skip duplicates (optional for efficiency)
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];

                // If exact match found, return immediately
                if (sum == target) return sum;

                // Update closest if this sum is closer
                if (Math.Abs(target - sum) < Math.Abs(target - closest)) {
                    closest = sum;
                }

                // Move pointers based on how sum compares to target
                if (sum < target) left++;
                else right--;
            }
        }

        return closest;
    }
}
