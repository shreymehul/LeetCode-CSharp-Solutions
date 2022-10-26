// 448. Find All Numbers Disappeared in an Array

// Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.

// Example 1:

// Input: nums = [4,3,2,7,8,2,3,1]
// Output: [5,6]
// Example 2:

// Input: nums = [1,1]
// Output: [2]

public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        bool[] present = new bool[nums.Length + 1];
        foreach(int num in nums)
            present[num] = true;
        IList<int> result = new List<int>();
        for(int i = 1 ; i < present.Length; i++){
            if(!present[i])
                result.Add(i);
        }
        return result;
    }
}