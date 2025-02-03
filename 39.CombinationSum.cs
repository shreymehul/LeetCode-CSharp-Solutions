// 39. Combination Sum
// Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of 
// candidates where the chosen numbers sum to target. You may return the combinations in any order.

// The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of 
// at least one of the chosen numbers is different.

// The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

// Example 1:
// Input: candidates = [2,3,6,7], target = 7
// Output: [[2,2,3],[7]]
// Explanation:
// 2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
// 7 is a candidate, and 7 = 7.
// These are the only two combinations.
// Example 2:
// Input: candidates = [2,3,5], target = 8
// Output: [[2,2,2,2],[2,3,3],[3,5]]
// Example 3:
// Input: candidates = [2], target = 1
// Output: []

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();
        FindCombination(candidates, target, 0,
                           new List<int>(),result);
        return result;
    }
    public void FindCombination(int[] candidates, int target, int idx, 
                                List<int> list, IList<IList<int>> result){
        if(target<0)
            return;
        if(target == 0)
            result.Add(new List<int>(list));
        for(int i = idx; i < candidates.Length; i++){
            list.Add(candidates[i]);
            FindCombination(candidates, target - candidates[i],i,list,result);
            list.RemoveAt(list.Count - 1);
        }
    }
}

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        FindCombinations(candidates, target, 0, new List<int>(), result);
        return result;
    }

    private void FindCombinations(int[] candidates, int target, int index,
                             List<int> current, IList<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current)); // Found a valid combination
            return;
        }

        if (target < 0 || index >= candidates.Length)
            return;

        // Include current candidate
        current.Add(candidates[index]);
        FindCombinations(candidates, target - candidates[index], index,
                         current, result); // Use same element
        current.RemoveAt(current.Count - 1);

        // Exclude current candidate and move to next
        FindCombinations(candidates, target, index + 1, current, result);
    }
}
