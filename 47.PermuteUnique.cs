// 47. Permutations II

// Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.
// Example 1:
// Input: nums = [1,1,2]
// Output:
// [[1,1,2],
//  [1,2,1],
//  [2,1,1]]
// Example 2:
// Input: nums = [1,2,3]
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

// Constraints:
// 1 <= nums.length <= 8
// -10 <= nums[i] <= 10

public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        // Sort the numbers to handle duplicates easily
        Array.Sort(nums);
        List<IList<int>> result = new List<IList<int>>();
        bool[] used = new bool[nums.Length];
        List<int> permute = new List<int>();
        FindPermute(nums, permute, used, result);
        return result;
    }

    private void FindPermute(int[] nums, List<int> permute, bool[] used, List<IList<int>> result) {
        if (permute.Count == nums.Length) {
            result.Add(new List<int>(permute));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            // Skip used numbers or duplicates
            if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])) {
                continue;
            }
            used[i] = true;
            permute.Add(nums[i]);
            FindPermute(nums, permute, used, result);
            used[i] = false;
            permute.RemoveAt(permute.Count - 1);
        }
    }
}