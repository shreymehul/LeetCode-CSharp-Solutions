// 2165. Smallest Value of the Rearranged Number
// You are given an integer num. Rearrange the digits of num such that its value is minimized and it does not contain any leading zeros.
// Return the rearranged number with minimal value.
// Note that the sign of the number does not change after rearranging the digits.

// Example 1:
// Input: num = 310
// Output: 103
// Explanation: The possible arrangements for the digits of 310 are 013, 031, 103, 130, 301, 310. 
// The arrangement with the smallest value that does not contain any leading zeros is 103.
// Example 2:
// Input: num = -7605
// Output: -7650
// Explanation: Some possible arrangements for the digits of -7605 are -7650, -6705, -5076, -0567.
// The arrangement with the smallest value that does not contain any leading zeros is -7650.

// Constraints:
// -1015 <= num <= 1015

public class Solution {
    public long SmallestNumber(long num) {
        bool isNegative = num < 0;
        num = Math.Abs(num);
        
        var numArray = num.ToString().ToCharArray();

        if (isNegative) {
            Array.Sort(numArray, (a, b) => b.CompareTo(a)); // Sort in descending order for negative numbers
        } else {
            Array.Sort(numArray); // Sort in ascending order for positive numbers
            // Move the first non-zero digit to the front to avoid leading zeros
            if (numArray[0] == '0') {
                for (int i = 1; i < numArray.Length; i++) {
                    if (numArray[i] != '0') {
                        // Swap the first element with the first non-zero element
                        char temp = numArray[0];
                        numArray[0] = numArray[i];
                        numArray[i] = temp;
                        break;
                    }
                }
            }
        }

        num = Int64.Parse(new string(numArray));
        num = isNegative ? -num : num;
        return num;
    }
}