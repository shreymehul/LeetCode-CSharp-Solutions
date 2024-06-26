// 78. Subsets

// Given an integer array nums of unique elements, return all possible subsets (the power set).
// The solution set must not contain duplicate subsets. Return the solution in any order.

// Example 1:
// Input: nums = [1,2,3]
// Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
// Example 2:
// Input: nums = [0]
// Output: [[],[0]]

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        int pow = (int)Math.Pow(2, nums.Length);
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < pow; i++)
        {
            IList<int> list = new List<int>();
            int ones = i;
            for(int j = 0; j < nums.Length; j++)
            {
                if((ones&1) != 0)
                    list.Add(nums[j]);
                ones >>= 1;
            } 
            result.Add(list);
        }
        return result;
    }
}

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Subsets(nums, 0, result, new List<int>());
        return result;
    }
    private void Subsets(int[] nums, int itr, IList<IList<int>> result, IList<int> set){
        if(itr == nums.Length){
            result.Add(new List<int>(set));
            return;
        }
        Subsets(nums, itr+1, result, set);
        set.Add(nums[itr]);
        Subsets(nums, itr+1, result, set);
        set.RemoveAt(set.Count -1);
    }
}