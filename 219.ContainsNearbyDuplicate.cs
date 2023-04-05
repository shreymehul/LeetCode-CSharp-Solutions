// 219. Contains Duplicate II
// Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such
// that nums[i] == nums[j] and abs(i - j) <= k.

public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!counter.ContainsKey(nums[i]))
                counter.Add(nums[i], i);
            else
            {
                if ((i - counter[nums[i]]) <= k)
                    return true;
                else
                    counter[nums[i]] = i;
            }
        }
        return false;
    }
}