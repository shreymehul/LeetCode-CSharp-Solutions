// 918. Maximum Sum Circular Subarray
// Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.

// A circular array means the end of the array connects to the beginning of the array. Formally, the next element of nums[i]
//  is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].

// A subarray may only include each element of the fixed buffer nums at most once. Formally, for a subarray nums[i],
// nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.

// Example 1:

// Input: nums = [1,-2,3,-2]
// Output: 3
// Explanation: Subarray [3] has maximum sum 3.
// Example 2:

// Input: nums = [5,-3,5]
// Output: 10
// Explanation: Subarray [5,5] has maximum sum 5 + 5 = 10.
// Example 3:

// Input: nums = [-3,-2,-3]
// Output: -2
// Explanation: Subarray [-2] has maximum sum -2.
 

// Constraints:

// n == nums.length
// 1 <= n <= 3 * 104
// -3 * 104 <= nums[i] <= 3 * 104


public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        int localMax = 0, globalMax = int.MinValue;
        int localMin = 0, globalMin = int.MaxValue;
        int totalSum = 0;

        foreach (int num in nums)
        {
            // Compute maximum subarray sum
            localMax = Math.Max(num, localMax + num);
            globalMax = Math.Max(globalMax, localMax);

            // Compute minimum subarray sum
            localMin = Math.Min(num, localMin + num);
            globalMin = Math.Min(globalMin, localMin);

            // Compute total sum
            totalSum += num;
        }

        // If all numbers are negative, return globalMax directly
        return globalMax < 0 ? globalMax : 
                                Math.Max(globalMax, totalSum - globalMin);
    }
}


public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return nums[0];

        int maxKadane = Kadane(nums); // Case 1: Non-circular subarray

        int totalSum = 0;
        for (int i = 0; i < n; i++)
        {
            totalSum += nums[i];
            nums[i] = -nums[i]; // Invert the elements to find the minimum subarray
        }

        int maxWrap = totalSum + Kadane(nums); // Case 2: Circular subarray

        // Handle edge case where all numbers are negative
        return maxWrap == 0 ? maxKadane : Math.Max(maxKadane, maxWrap);
    }

    private int Kadane(int[] nums)
    {
        int localMax = nums[0], globalMax = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            localMax = Math.Max(nums[i], localMax + nums[i]);
            globalMax = Math.Max(globalMax, localMax);
        }
        return globalMax;
    }
}

// Approch: Find MaxSum in non-circular array. Find total Sum. Negate all element and Find MaxSum (MinSum of original array).
// Max sum will be either MaxSum of non-circular array or TotalSum-MinSum in case of circular array.

// Using Kadane's Algorithm for Non-Circular Case:
// The standard Kadane algorithm finds the maximum sum of a contiguous subarray in 𝑂(𝑛)time.
// It does this by maintaining a localMax sum and updating a globalMax whenever the local sum exceeds the current best.
// Example: nums = [5, -3, 5]
// Kadane would return 7 because [5, 5] is the best non-circular subarray.

// Handling Circular Arrays (Wrap-Around):
// The sum of a circular subarray can be computed as:
// totalSum - minSubarraySum
// Why? Because if you "wrap around," the subarray we exclude is equivalent to the minimum subarray in the original array.
// To find the minimum subarray, invert the array elements (turn positive into negative and vice versa) and apply Kadane's algorithm.

// Final Result:
// Compute two possible maximums:
// maxKadane: Maximum subarray without wrapping.
// maxWrap: Circular maximum subarray computed as: totalSum + Kadane(-nums)
// Compare these two and return the larger value.

// Edge Case Handling:
// If all numbers in the array are negative, maxWrap becomes zero. In this case, return only maxKadane.