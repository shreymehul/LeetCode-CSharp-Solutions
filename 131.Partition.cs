// 131. Palindrome Partitioning
// Given a string s, partition s such that every substring of the partition is a  palindrome
// Return all possible palindrome partitioning of s.

// Example 1:
// Input: s = "aab"
// Output: [["a","a","b"],["aa","b"]]
// Example 2:
// Input: s = "a"
// Output: [["a"]]

// Constraints:
// 1 <= s.length <= 16
// s contains only lowercase English letters.

public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> result = new List<IList<string>>();
        Backtrack(s, 0, result, new List<string>());
        return result;
    }

    private void Backtrack(string s, int start, IList<IList<string>> result, 
    IList<string> currentPartition) {
        if (start == s.Length) {
            result.Add(new List<string>(currentPartition));
            return;
        }

        for (int end = start; end < s.Length; end++) {
            if (IsPalindrome(s, start, end)) {
                currentPartition.Add(s.Substring(start, end - start + 1));
                Backtrack(s, end + 1, result, currentPartition);
                currentPartition.RemoveAt(currentPartition.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int start, int end) {
        while (start < end) {
            if (s[start] != s[end]) {
                return false;
            }
            start++;
            end--;
        }
        return true;
    }
}