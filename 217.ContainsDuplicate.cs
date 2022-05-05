// 217. Contains Duplicate
// Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!counter.ContainsKey(nums[i]))
                counter.Add(nums[i], 1);
            else
                return true;
        }
        return false;
    }
}