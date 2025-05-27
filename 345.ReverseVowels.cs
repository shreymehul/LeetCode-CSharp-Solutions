// 345. Reverse Vowels of a String

// Given a string s, reverse only all the vowels in the string and return it.
// The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

// Example 1:
// Input: s = "IceCreAm"
// Output: "AceCreIm"
// Explanation:
// The vowels in s are ['I', 'e', 'e', 'A']. On reversing the vowels, s becomes "AceCreIm".
// Example 2:
// Input: s = "leetcode"
// Output: "leotcede"

// Constraints:
// 1 <= s.length <= 3 * 105
// s consist of printable ASCII characters.

public class Solution {
    public string ReverseVowels(string s) {
        List<char> vowels = new();
        string vowelSet = "aeiouAEIOU";

        // Collect vowels
        foreach (char c in s) {
            if (vowelSet.Contains(c))
                vowels.Add(c);
        }

        // Replace vowels in reverse
        char[] result = s.ToCharArray();
        for (int i = 0; i < result.Length; i++) {
            if (vowelSet.Contains(result[i])) {
                result[i] = vowels[^1]; // Last vowel
                vowels.RemoveAt(vowels.Count - 1);
            }
        }

        return new string(result);
    }
}
