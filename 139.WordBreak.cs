// 139. Word Break

// Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence 
// of one or more dictionary words.
// Note that the same word in the dictionary may be reused multiple times in the segmentation.

// Example 1:
// Input: s = "leetcode", wordDict = ["leet","code"]
// Output: true
// Explanation: Return true because "leetcode" can be segmented as "leet code".
// Example 2:
// Input: s = "applepenapple", wordDict = ["apple","pen"]
// Output: true
// Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
// Note that you are allowed to reuse a dictionary word.
// Example 3:
// Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
// Output: false

// Constraints:
// 1 <= s.length <= 300
// 1 <= wordDict.length <= 1000
// 1 <= wordDict[i].length <= 20
// s and wordDict[i] consist of only lowercase English letters.
// All the strings of wordDict are unique.

public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        // Convert wordDict to a HashSet for O(1) lookups
        HashSet<string> dict = new HashSet<string>(wordDict);
        
        // dp[i] means: can s[0..i-1] be segmented into words in the dict?
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true; // Empty string is always segmentable

        // Iterate over the end index of substrings
        for (int i = 1; i <= s.Length; i++) {
            // Iterate over the start index of substrings
            for (int j = 0; j < i; j++) {
                // If s[0..j-1] is segmentable and s[j..i-1] is in dict, then s[0..i-1] is segmentable
                if (dp[j] && dict.Contains(s.Substring(j, i - j))) {
                    dp[i] = true;
                    break; // No need to check other j's once we find a valid segmentation
                }
            }
        }

        // Return whether the entire string s[0..s.Length-1] can be segmented
        return dp[s.Length];
    }
}
