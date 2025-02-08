// 1995. Count Special Quadruplets
// Given a 0-indexed integer array nums, return the number of distinct quadruplets (a, b, c, d) such that:
// nums[a] + nums[b] + nums[c] == nums[d], and
// a < b < c < d

// Example 1:
// Input: nums = [1,2,3,6]
// Output: 1
// Explanation: The only quadruplet that satisfies the requirement is (0, 1, 2, 3) because 1 + 2 + 3 == 6.

// Example 2:
// Input: nums = [3,3,6,4,5]
// Output: 0
// Explanation: There are no such quadruplets in [3,3,6,4,5].
// Example 3:
// Input: nums = [1,1,1,3,5]

// Output: 4
// Explanation: The 4 quadruplets that satisfy the requirement are:
// - (0, 1, 2, 3): 1 + 1 + 1 == 3
// - (0, 1, 3, 4): 1 + 1 + 3 == 5
// - (0, 2, 3, 4): 1 + 1 + 3 == 5
// - (1, 2, 3, 4): 1 + 1 + 3 == 5

// Constraints:
// 4 <= nums.length <= 50
// 1 <= nums[i] <= 100


//BruteForce: O(n^4)
public class Solution {
    public int CountQuadruplets(int[] nums) {
        int result = 0;
        for(int i = 0; i < nums.Length-3; i++)
            for(int j = i+1; j < nums.Length-2; j++)
                for(int k = j+1; k < nums.Length-1; k++)
                    for(int l = k+1; l < nums.Length; l++)
                        if(nums[l] == nums[i] + nums[j] + nums[k])
                            result++;
        
        return result;
    }
}

// O(n^3)
public class Solution {
    public int CountQuadruplets(int[] nums) {
        int n = nums.Length;
        int result = 0;

        // Dictionary to store frequency of sums nums[d] - nums[c]
        var map = new Dictionary<int, int>();

        for (int c = n - 2; c >= 2; c--) {
            // Add nums[d] - nums[c] to the map for potential matches
            if (!map.ContainsKey(nums[c + 1])) 
                map[nums[c + 1]] = 0;
            map[nums[c + 1]]++;

            // Look for valid (a, b, c, d)
            for (int a = 0; a < c; a++) {
                for (int b = a + 1; b < c; b++) {
                    int targetSum = nums[a] + nums[b] + nums[c];
                    if (map.ContainsKey(targetSum)) {
                        result += map[targetSum];
                    }
                }
            }
        }

        return result;
    }
}
