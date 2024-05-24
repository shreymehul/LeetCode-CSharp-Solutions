// 2597. The Number of Beautiful Subsets
// You are given an array nums of positive integers and a positive integer k.
// A subset of nums is beautiful if it does not contain two integers with an absolute difference equal to k.
// Return the number of non-empty beautiful subsets of the array nums.
// A subset of nums is an array that can be obtained by deleting some (possibly none) elements from nums. Two subsets are different if and only if the chosen indices to delete are different.

// Example 1:
// Input: nums = [2,4,6], k = 2
// Output: 4
// Explanation: The beautiful subsets of the array nums are: [2], [4], [6], [2, 6].
// It can be proved that there are only 4 beautiful subsets in the array [2,4,6].
// Example 2:
// Input: nums = [1], k = 1
// Output: 1
// Explanation: The beautiful subset of the array nums is [1].
// It can be proved that there is only 1 beautiful subset in the array [1].

// Constraints:
// 1 <= nums.length <= 20
// 1 <= nums[i], k <= 1000

public class Solution {
    public int BeautifulSubsets(int[] nums, int k) {
        Dictionary<int, int> map = new ();
        foreach(int num in nums)
            if(!map.ContainsKey(num))
                map[num] = 0;
        int result = 0;
        Subset(nums, 0, k, map, ref result);
        return result - 1; 
    }
    private void Subset(int[] nums, int itr, int k, Dictionary<int, int> map, ref int result){
        if(itr == nums.Length){
            result++;
            return;
        }
        int add =  nums[itr] + k, sub = nums[itr] - k;
        if((!map.ContainsKey(add) || map[add] == 0) && 
                (!map.ContainsKey(sub) || map[sub] == 0)){
                    map[nums[itr]]++;
                    Subset(nums, itr+1, k, map, ref result);
                    map[nums[itr]]--;
                }
        Subset(nums, itr+1, k, map, ref result);
    }
}