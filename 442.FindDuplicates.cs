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

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        //intuution: we can use the array itself to mark the visited elements
        // we can use the index of the array to mark the visited elements
        // we can use the negative sign to mark the visited elements
        // if we see the element again, we can add it to the result
        // we can use the absolute value of the element to get the index
        IList<int> Duplicates = new List<int>();

        for(int i = 0; i < nums.Length; i++){
            int idx = Math.Abs(nums[i]) - 1;
            if(nums[idx] < 0)
                Duplicates.Add(idx + 1);
            else
                nums[idx] = -nums[idx];
        }
        return Duplicates;
    }
}