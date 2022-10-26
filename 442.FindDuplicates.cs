// 442. Find All Duplicates in an Array
// Given an integer array nums of length n where all the integers of nums are in the range [1, n] and each integer appears once or twice, return an array of all the integers that appears twice.
// You must write an algorithm that runs in O(n) time and uses only constant extra space.

// Example 1:

// Input: nums = [4,3,2,7,8,2,3,1]
// Output: [2,3]
// Example 2:

// Input: nums = [1,1,2]
// Output: [1]
// Example 3:

// Input: nums = [1]
// Output: []

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        int[] count = new int[nums.Length+1];
        foreach(int num in nums)
            count[num]++;
        IList<int> result = new List<int>();
        for(int i = 0; i < count.Length; i++){
            if(count[i] ==2)
                result.Add(i);
        }
        return result;
    }
}