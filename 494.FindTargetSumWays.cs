// 494. Target Sum

// You are given an integer array nums and an integer target.

// You want to build an expression out of nums by adding one of the symbols '+' and '-' before each integer in nums and
// then concatenate all the integers.

// For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate them to build the expression 
// "+2-1".
// Return the number of different expressions that you can build, which evaluates to target.

// Example 1:
// Input: nums = [1,1,1,1,1], target = 3
// Output: 5
// Explanation: There are 5 ways to assign symbols to make the sum of nums be target 3.
// -1 + 1 + 1 + 1 + 1 = 3
// +1 - 1 + 1 + 1 + 1 = 3
// +1 + 1 - 1 + 1 + 1 = 3
// +1 + 1 + 1 - 1 + 1 = 3
// +1 + 1 + 1 + 1 - 1 = 3

// Example 2:
// Input: nums = [1], target = 1
// Output: 1
 

// Constraints:
// 1 <= nums.length <= 20
// 0 <= nums[i] <= 1000
// 0 <= sum(nums[i]) <= 1000
// -1000 <= target <= 1000

//Time: O(2^n)
public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        return FindTarget(nums, target, 0);
    }
    public int FindTarget(int[] nums, int target, int index){
        if(index == nums.Length && target == 0)
            return 1;
        if(index == nums.Length)
            return 0;
        return FindTarget(nums, target + nums[index], index + 1)
                + FindTarget(nums, target - nums[index], index + 1);
    }
}

//Time: O(n×sum(nums))
public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        var memo = new Dictionary<(int, int), int>();
        return FindTarget(nums, target, 0, memo);
    }

    private int FindTarget(int[] nums, int target, int index, 
                            Dictionary<(int, int), int> memo) {
        // Base cases
        if (index == nums.Length) 
            return target == 0 ? 1 : 0;
        
        // Check memo
        if (memo.ContainsKey((index, target))) 
            return memo[(index, target)];
        
        // Explore both possibilities: add and subtract current number
        int count = FindTarget(nums, target + nums[index], index + 1, memo)
                  + FindTarget(nums, target - nums[index], index + 1, memo);
        
        // Save result to avoid recomputation
        memo[(index, target)] = count;
        return count;
    }
}


public class Solution {
    
    public int FindTargetSumWays(int[] nums, int target) {
        int sum =0;
        foreach(var num in nums)
            sum += num;

        //Ensures the target is achievable and (sum + target) / 2 is an integer.    
        if(Math.Abs(target)>sum || (sum+target)%2 != 0)
            return 0;
        
        int subTarget = (sum+target)/2;
        int[,] dpCount = new int[nums.Length+1,subTarget+1];
        
        // dpCount[i, j] stores the count of ways to form sum j using the first i elements.
        // dpCount[0, 0] = 1: There's one way to make sum 0 — by selecting no elements.
        dpCount[0,0] = 1;
        for(int i=0;i<=nums.Length;i++) {
            dpCount[i,0] = 1;
        }
        
        for(int j=1;j<=subTarget;j++) {
            dpCount[0,j] = 0;
        }

        // If the current element nums[i - 1] is less than or equal to the current target j, you have two choices:
        // Exclude it (dpCount[i - 1, j]).
        // Include it (dpCount[i - 1, j - nums[i - 1]]).
        for(int i=1; i<=nums.Length; i++){
            for(int j=0; j<=subTarget; j++ ){
                dpCount[i,j] = dpCount[i-1,j];
                if(nums[i-1]<= j)
                   dpCount[i,j] += dpCount[i-1,j-nums[i-1]];
            }
        }
        return dpCount[nums.Length,subTarget];
    }
}

// Core Idea:
// Given an integer array nums and a target target, you need to build expressions using + and - before each integer such that 
// the sum evaluates to target.

// Let's represent two subsets:
// Subset P contributes positively to the sum.
// Subset N contributes negatively to the sum.
// Thus, the equation becomes: P - N = target
// Also,                       P + N = sum(nums)
// Adding both equations:         2P = sum(nums) + target
// Therefore,                      P = (sum(nums) + target) / 2
// If the above equation results in a non-integer or is negative, there's no valid solution.