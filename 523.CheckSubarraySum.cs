// 523. Continuous Subarray Sum
// Given an integer array nums and an integer k, return true if nums has a continuous subarray of size at least two whose elements sum up to a multiple of k, or false otherwise.

// An integer x is a multiple of k if there exists an integer n such that x = n * k. 0 is always a multiple of k.

// Example 1:

// Input: nums = [23,2,4,6,7], k = 6
// Output: true
// Explanation: [2, 4] is a continuous subarray of size 2 whose elements sum up to 6.
// Example 2:

// Input: nums = [23,2,6,4,7], k = 6
// Output: true
// Explanation: [23, 2, 6, 4, 7] is an continuous subarray of size 5 whose elements sum up to 42.
// 42 is a multiple of 6 because 42 = 7 * 6 and 7 is an integer.
// Example 3:

// Input: nums = [23,2,6,4,7], k = 13
// Output: false

//TLE 
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        int[] preSum = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++){
            preSum[i] = nums[i];
            if(i>0)
                preSum[i] += preSum[i-1];
            if (i > 1 && preSum[i] % k == 0)
                return true;
        }
        for(int i = -1; i < preSum.Length - 2; i++){
            for(int j = i + 2; j < preSum.Length; j++){
                if (i == -1) { 
                    if (preSum[j] % k == 0)
                        return true;
                }
                else if((preSum[j] - preSum[i]) % k == 0)
                    return true;
            }
        }
        return false;
    }
}


//
// If we create a prefix sum array (prefix) of the given nums array then,
// Let two indices low and high, low < high.
// Now if we have to find the sum from low to high we can easily do prefix[high] - prefix[low - 1], which we give the sum of that subarray.
// But to find an answer we have to do step 3 for all the subarrays which will exceed the TC.
// Now here comes the math part
// Let diff be the difference between two indices a and b, a < b.
// So diff = prefix[b] - prefix[a]. Take mod by k both sides
// diff % k = (prefix[b] - prefix[a]) % k.
// diff % k = prefix[b] % k - prefix[a] % k.
// Now to be a valid answer diff % kshould be equal to 0.
// Therefore,0 = prefix[b] % k - prefix[a] % k.
// prefix[b] % k = prefix[a] % k. Final Derivation
// Now our problem reduces to that, we have to find two indices a and b such that prefix[b] % k = prefix[a] % k.

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int prefixSum = 0;
        
        for(int i = 0; i < nums.Length; i++){
            // Prefix sum which will have sum of all previous elements.
            prefixSum += nums[i];
            
            // Mod by k
            prefixSum %= k;
            // If our prefixSum becomes 0 at any point for index gretaer than 0 the return true.
            if(prefixSum == 0 && i > 0){
                return true;
            }
            // If prefixSum is already there in map and the difference between current index and that index gretaer than 1.
            if(map.ContainsKey(prefixSum) && i - map[prefixSum] > 1){
                return true;
            }
            
			// At last put the prefixSum and the current in the map.
            if(!map.ContainsKey(prefixSum)){
                map[prefixSum] = i;
            }            
            
        }
        // Return false if no such subarray is found.
        return false;
    }
}