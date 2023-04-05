// 90. Subsets II

// Given an integer array nums that may contain duplicates, return all possible subsets (the power set).

// The solution set must not contain duplicate subsets. Return the solution in any order.

// Example 1:
// Input: nums = [1,2,2]
// Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]
// Example 2:
// Input: nums = [0]
// Output: [[],[0]]

public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);  
        IList<IList<int>> result = new List<IList<int>>();
        FindSubsets(nums,0,new List<int>(), result);
        return result;
    }
    public void FindSubsets(int[] nums, int idx, List<int> list, IList<IList<int>> result){
        result.Add(new List<int>(list));
        for(int i = idx; i < nums.Length; i++){
            //can contain duplicate element so will alow to add duplicate value for first time.
            //But as it can't contain duplicate list so will not allow more than once.
            if(i != idx && nums[i] == nums[i-1]) continue;
            list.Add(nums[i]);
            FindSubsets(nums,i+1,list, result);   
            list.RemoveAt(list.Count-1);
        }
    }
}