// 46. Permutations

// Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

// Example 1:
// Input: nums = [1,2,3]
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
// Example 2:
// Input: nums = [0,1]
// Output: [[0,1],[1,0]]
// Example 3:
// Input: nums = [1]
// Output: [[1]]

public class Solution
{

    public IList<IList<int>> Permute(int[] nums)
    {
        List<int> permut = new List<int>();
        List<int> lnums = new List<int>(nums);
        IList<IList<int>> result = new List<IList<int>>();
        FindPermutaion(lnums, permut, result);
        return result;
    }
    public void FindPermutaion
        (IList<int> nums, IList<int> permut, IList<IList<int>> result)
    {

        if (nums.Count == 0)
        {
            result.Add(new List<int>(permut));
        }

        for (int i = 0; i < nums.Count; i++)
        {
            IList<int> temp = new List<int>(nums);
            permut.Add(nums[i]);
            //remove used number
            temp.RemoveAt(i);
            FindPermutaion(temp, permut, result);
            permut.Remove(nums[i]);
        }
    }
}

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Permute(nums, result, new List<int>(), new bool[nums.Length]);
        return result;
    }
    public void Permute(int[] nums, IList<IList<int>> result, IList<int> subset, 
        bool[] used){
        if(subset.Count == nums.Length){
            result.Add(new List<int>(subset));
        }
        for(int i = 0; i < nums.Length; i++){
            if(!used[i]){
                used[i] = true;
                subset.Add(nums[i]);
                Permute(nums, result, subset, used);
                used[i] = false;
                subset.RemoveAt(subset.Count -1);
            }
        }
    
    }
}