// 40. Combination Sum II
// Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in 
// candidates where the candidate numbers sum to target.
// Each number in candidates may only be used once in the combination.
// Note: The solution set must not contain duplicate combinations.
// Example 1:
// Input: candidates = [10,1,2,7,6,1,5], target = 8
// Output: 
// [
// [1,1,6],
// [1,2,5],
// [1,7],
// [2,6]
// ]
// Example 2:
// Input: candidates = [2,5,2,1,2], target = 5
// Output: 
// [
// [1,2,2],
// [5]
// ]

public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();
        FindCombination(candidates.OrderBy(x=>x).ToArray(), target, 0,
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
            if(i > idx && candidates[i] == candidates[i-1])
                continue;
            if(target >= candidates[i]){
                list.Add(candidates[i]);
                FindCombination(candidates, target - candidates[i],i+1,list,result);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}