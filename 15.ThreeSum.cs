// 15. 3Sum

// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

// Notice that the solution set must not contain duplicate triplets.

// Example 1:
// Input: nums = [-1,0,1,2,-1,-4]
// Output: [[-1,-1,2],[-1,0,1]]
// Explanation: 
// nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
// nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
// nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
// The distinct triplets are [-1,0,1] and [-1,-1,2].
// Notice that the order of the output and the order of the triplets does not matter.
// Example 2:
// Input: nums = [0,1,1]
// Output: []
// Explanation: The only possible triplet does not sum up to 0.
// Example 3:
// Input: nums = [0,0,0]
// Output: [[0,0,0]]
// Explanation: The only possible triplet sums up to 0.

public class Solution {
    //intuition: We can solve this problem by using two pointers.
    //We can sort the array and then iterate through the array.
    //For each element, we can use two pointers to find the other two elements that sum up to 0.
    //We can skip duplicate elements to avoid duplicate triplets.
    //Time complexity: O(n^2)
    //Space complexity: O(1)
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        
        IList<IList<int>> result = new List<IList<int>>();
        
        int pFirst = 0;
        for(int i = nums.Length-1; i > 1; i--){
            if(i != nums.Length-1 && nums[i] == pFirst)
                continue;
            int first = nums[i];
            int pSecond = 0;
            for(int j = i-1; j > 0; j--){
                if(j != i-1 && nums[j] == pSecond)
                    continue;
                int second = nums[j];
                int third = 0 - (first + second);
                
                var exist = Array.BinarySearch<int>(nums, 0, j, third);
                if(exist >= 0)
                {
                    result.Add(new List<int>(){first, second, third});
                }
                
                pSecond = second;
            }
            pFirst = first;
        }
        return result;
    }
}