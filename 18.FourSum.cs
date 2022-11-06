// 18. 4Sum

// Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

// 0 <= a, b, c, d < n
// a, b, c, and d are distinct.
// nums[a] + nums[b] + nums[c] + nums[d] == target
// You may return the answer in any order.

// Example 1:

// Input: nums = [1,0,-1,0,-2,2], target = 0
// Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
// Example 2:

// Input: nums = [2,2,2,2,2], target = 8
// Output: [[2,2,2,2]]

public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 3; i++)
            {
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    int left = j + 1,
                        right = nums.Length - 1;
                    long subTarget = (long)target - (long)nums[i] - (long)nums[j];
                    while (left < right)
                    {
                        long twoSum = nums[left] + nums[right];
                        if (twoSum < subTarget)
                            left++;
                        else if (twoSum > subTarget)
                            right--;
                        else if (twoSum == subTarget)
                        {
                            result.Add(new List<int> 
                                       { nums[i], nums[j], nums[left], nums[right] });
                            while (left < right && 
                                   nums[left] == result[result.Count - 1][2])
                                left++;
                            while (left < right && 
                                   nums[right] == result[result.Count - 1][3])
                                right--;
                        }
                    }
                    while (j < nums.Length - 2 && nums[j+1] == nums[j])
                        j++;
                }
                while (i < nums.Length - 3 && nums[i+1] == nums[i])
                    i++;
            }
            return result;
    }
}