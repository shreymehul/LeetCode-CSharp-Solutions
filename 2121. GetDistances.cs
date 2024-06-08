// 2121. Intervals Between Identical Elements

// You are given a 0-indexed array of n integers arr.
// The interval between two elements in arr is defined as the absolute difference between their indices. More formally, the interval between arr[i] and arr[j] is |i - j|.
// Return an array intervals of length n where intervals[i] is the sum of intervals between arr[i] and each element in arr with the same value as arr[i].
// Note: |x| is the absolute value of x.

// Example 1:
// Input: arr = [2,1,3,1,2,3,3]
// Output: [4,2,7,2,4,4,5]
// Explanation:
// - Index 0: Another 2 is found at index 4. |0 - 4| = 4
// - Index 1: Another 1 is found at index 3. |1 - 3| = 2
// - Index 2: Two more 3s are found at indices 5 and 6. |2 - 5| + |2 - 6| = 7
// - Index 3: Another 1 is found at index 1. |3 - 1| = 2
// - Index 4: Another 2 is found at index 0. |4 - 0| = 4
// - Index 5: Two more 3s are found at indices 2 and 6. |5 - 2| + |5 - 6| = 4
// - Index 6: Two more 3s are found at indices 2 and 5. |6 - 2| + |6 - 5| = 5
// Example 2:
// Input: arr = [10,5,10,10]
// Output: [5,0,3,4]
// Explanation:
// - Index 0: Two more 10s are found at indices 2 and 3. |0 - 2| + |0 - 3| = 5
// - Index 1: There is only one 5 in the array, so its sum of intervals to identical elements is 0.
// - Index 2: Two more 10s are found at indices 0 and 3. |2 - 0| + |2 - 3| = 3
// - Index 3: Two more 10s are found at indices 0 and 2. |3 - 0| + |3 - 2| = 4

// Constraints:
// n == arr.length
// 1 <= n <= 105
// 1 <= arr[i] <= 105

//-----------------------
// EXPLANATION
//-----------------------
// Initialization:
// sumIndex: Keeps track of the cumulative sum of indices for each unique number.
// freqIndex: Keeps track of the frequency of each unique number.
// intervals: The result array to store the total distances.

// First Pass (Left to Right):
// For each element arr[i], if it has been seen before, calculate the interval contribution from the left.
// Update sumIndex and freqIndex to include the current index i.

// Second Pass (Right to Left):
// For each element arr[i], if it has been seen before, calculate the interval contribution from the right and add it to the previous value.
// Update sumIndex and freqIndex to include the current index i.

// Time Complexity:
// O(n): Each pass through the array (left-to-right and right-to-left) takes linear time, resulting in a total time complexity of O(n).

// Space Complexity:
// O(n): The dictionaries used to keep track of the cumulative sums and frequencies can grow up to the size of the input array in the worst case.

public class Solution {
    public long[] GetDistances(int[] arr) {
        // Dictionaries to store the cumulative sum of indices and the frequency of each element
        Dictionary<int, long> sumIndex = new();
        Dictionary<int, int> freqIndex = new();
        
        long[] intervals = new long[arr.Length];
        
        // First pass: left to right
        for (int i = 0; i < arr.Length; i++) {
            int currNum = arr[i];
            int freq = 0;
            long sum = 0;
            
            // Check if the current number has been seen before
            if (sumIndex.ContainsKey(currNum)) {
                freq = freqIndex[currNum];
                sum = sumIndex[currNum];
                // Calculate the interval contribution from the left
                intervals[i] = freq * (long)i - sum;
            }
            
            // Update the cumulative sum and frequency for the current number
            sumIndex[currNum] = sum + i;
            freqIndex[currNum] = freq + 1;
        }
        
        // Clear dictionaries to reuse them for the second pass
        sumIndex.Clear();
        freqIndex.Clear();
        
        // Second pass: right to left
        for (int i = arr.Length - 1; i >= 0; i--) {
            int currNum = arr[i];
            int freq = 0;
            long sum = 0;
            
            // Check if the current number has been seen before
            if (sumIndex.ContainsKey(currNum)) {
                freq = freqIndex[currNum];
                sum = sumIndex[currNum];
                // Add the interval contribution from the right
                intervals[i] += sum - freq * (long)i;
            }
            
            // Update the cumulative sum and frequency for the current number
            sumIndex[currNum] = sum + i;
            freqIndex[currNum] = freq + 1;
        }
        
        return intervals;
    }
}

// TLE Solution
public class Solution {
    public long[] GetDistances(int[] arr) {
        Dictionary<int, List<int>> mapIndex = new();
        for(int i = 0; i < arr.Length; i++){
            if(!mapIndex.ContainsKey(arr[i]))
                mapIndex[arr[i]] = new List<int>();
            mapIndex[arr[i]].Add(i);
        }
        long[] intervals = new long[arr.Length];

        for(int i = 0; i < arr.Length; i++){
            long interval = 0;
            foreach(var indx in mapIndex[arr[i]]){
                interval += Math.Abs(indx - i);
            }
            intervals[i] = interval;
        }
        return intervals;
    }
}