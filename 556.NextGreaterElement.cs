// 556. Next Greater Element III

// Given a positive integer n, find the smallest integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive integer exists, return -1.
// Note that the returned integer should fit in 32-bit integer, if there is a valid answer but it does not fit in 32-bit integer, return -1.
// Example 1:
// Input: n = 12
// Output: 21

// Example 2:
// Input: n = 21
// Output: -1

// Constraints:
// 1 <= n <= 231 - 1

// ## Digit Extraction:
// 1. The digits of the input number n are extracted and stored in a list in reverse order. This helps in easily manipulating the digits.
// 2. The list is then reversed to restore the original order of the digits.

// ## Next Permutation Logic:
// 1. The NextPermutation method is used to find the next lexicographical permutation of the list of digits.
// 2. The algorithm first identifies the rightmost position where the digits are in decreasing order. This identifies the pivot point for the swap.
// 3. If no such position is found, it means the digits are in the highest possible order, and there is no next greater permutation.
// 4. It then finds the smallest digit on the right side of the pivot that is larger than the pivot.
// 5. These two digits are swapped.
// 6. The sequence of digits to the right of the pivot is reversed to get the smallest lexicographical order for the new sequence.

// ## Reconstructing the Number:
// 1. The list of digits, now in the next permutation order, is used to reconstruct the number.
// 2. The reconstructed number is checked to ensure it fits within the 32-bit signed integer range. If it exceeds, -1 is returned.
// 3. 
// # Complexity
// - Time complexity:
// O(d) (where d = no of digits)

// - Space complexity:
// O(d)


public class Solution {
    public int NextGreaterElement(int n) {
        List<int> num = new List<int>();
        int temp = n;
        
        // Extract the digits of the number and add to the list
        while (temp > 0) {
            num.Add(temp % 10);
            temp /= 10;
        }
        num.Reverse(); // Reverse to get the original order of digits
        
        // Find the next permutation of the digits
        if (!NextPermutation(num)) {
            return -1; // If no next permutation, return -1
        }
        
        long result = 0;
        
        // Reconstruct the number from the list of digits
        foreach (var digit in num) {
            result = result * 10 + digit;
            if (result > int.MaxValue) {
                return -1; // If result exceeds int range, return -1
            }
        }
        
        return (int)result; // Cast result to int and return
    }

    private bool NextPermutation(List<int> num) {
        int i = num.Count - 2;
        
        // Find the first decreasing element from the end
        while (i >= 0 && num[i] >= num[i + 1]) {
            i--;
        }
        
        // If no such element exists, the number is the largest permutation
        if (i < 0) {
            return false;
        }
        
        int j = num.Count - 1;
        
        // Find the first element larger than num[i] from the end
        while (num[j] <= num[i]) {
            j--;
        }
        
        // Swap num[i] and num[j]
        (num[i], num[j]) = (num[j], num[i]);

        // Reverse the sequence from i + 1 to the end to get the next permutation
        num.Reverse(i + 1, num.Count - (i + 1));
        
        return true; // Successfully found the next permutation
    }
}

// using char array
public class Solution {
    public int NextGreaterElement(int n) {
        var num = n.ToString().ToCharArray();
        
        // Find the next permutation
        if (!NextPermutation(num)) {
            return -1;
        }
        
        // Try to parse the result and handle the potential overflow
        long result = long.Parse(new string(num));
        if (result > int.MaxValue) {
            return -1;
        }
        
        return (int)result;
    }

    private bool NextPermutation(char[] num) {
        int i = num.Length - 2;
        
        // Find the first decreasing element from the end
        while (i >= 0 && num[i] >= num[i + 1]) {
            i--;
        }
        
        // If no such element exists, the number is the largest permutation
        if (i < 0) {
            return false;
        }
        
        int j = num.Length - 1;
        
        // Find the first element larger than num[i] from the end
        while (num[j] <= num[i]) {
            j--;
        }
        
        // Swap num[i] and num[j]
        char temp = num[i];
        num[i] = num[j];
        num[j] = temp;

        // Reverse the sequence from i + 1 to the end
        Array.Reverse(num, i + 1, num.Length - (i + 1));
        return true;
    }
}
