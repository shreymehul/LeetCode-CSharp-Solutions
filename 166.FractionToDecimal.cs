// 166. Fraction to Recurring Decimal
// Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
// If the fractional part is repeating, enclose the repeating part in parentheses.
// If multiple answers are possible, return any of them.
// // It is guaranteed that the length of the answer string is less than 104 for all the given inputs.

// Example 1:
// Input: numerator = 1, denominator = 2
// Output: "0.5"
// Example 2:
// Input: numerator = 2, denominator = 1
// Output: "2"

// Example 3:
// Input: numerator = 4, denominator = 333
// Output: "0.(012)"

// Constraints:
// -231 <= numerator, denominator <= 231 - 1
// denominator != 0

// Time Complexity: O(d) — where d is the denominator, as each remainder is tracked once.
// Space Complexity: O(d) — Dictionary to store remainders.

public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        if (numerator == 0) return "0";

        StringBuilder result = new StringBuilder();

        // Handle negative numbers
        if ((numerator < 0) ^ (denominator < 0)) {
            result.Append("-");
        }

        // Convert to long to avoid overflow issues
        long num = Math.Abs((long)numerator);
        long denom = Math.Abs((long)denominator);

        // Append the integer part
        result.Append(num / denom);
        num %= denom;

        if (num == 0) return result.ToString();

        // Handle fractional part
        result.Append(".");
        Dictionary<long, int> remainderIndexMap = new();

        while (num != 0) {
            if (remainderIndexMap.ContainsKey(num)) {
                result.Insert(remainderIndexMap[num], "(");
                result.Append(")");
                break;
            }

            remainderIndexMap[num] = result.Length;
            num *= 10;
            result.Append(num / denom);
            num %= denom;
        }

        return result.ToString();
    }
}
