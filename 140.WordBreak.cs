// 140. Word Break II

// Given a string s and a dictionary of strings wordDict, add spaces in s to construct a sentence where each word is a 
// valid dictionary word. Return all such possible sentences in any order.
// Note that the same word in the dictionary may be reused multiple times in the segmentation.

// Example 1:
// Input: s = "catsanddog", wordDict = ["cat","cats","and","sand","dog"]
// Output: ["cats and dog","cat sand dog"]
// Example 2:
// Input: s = "pineapplepenapple", wordDict = ["apple","pen","applepen","pine","pineapple"]
// Output: ["pine apple pen apple","pineapple pen apple","pine applepen apple"]
// Explanation: Note that you are allowed to reuse a dictionary word.
// Example 3:
// Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
// Output: []

// Constraints:
// 1 <= s.length <= 20
// 1 <= wordDict.length <= 1000
// 1 <= wordDict[i].length <= 10
// s and wordDict[i] consist of only lowercase English letters.
// All the strings of wordDict are unique.
// Input is generated in a way that the length of the answer doesn't exceed 105.

public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        HashSet<string> dict = new(wordDict);
        Dictionary<int, List<string>> memo = new(); // Memoization to store results starting at each index
        return DFS(s, 0, dict, memo);
    }

    private List<string> DFS(string s, int start, HashSet<string> dict, Dictionary<int, List<string>> memo) {
        // If we've already computed results starting from 'start', return them
        if (memo.ContainsKey(start)) return memo[start];

        List<string> result = new();

        // If we've reached the end of the string, return a list with empty string to help with sentence building
        if (start == s.Length) {
            result.Add("");
            return result;
        }

        // Try every possible end index from start+1 to end of string
        for (int end = start + 1; end <= s.Length; end++) {
            string word = s.Substring(start, end - start);

            // If the current prefix is a valid word
            if (dict.Contains(word)) {
                // Recursively build the rest of the sentence from position 'end'
                List<string> subSentences = DFS(s, end, dict, memo);

                // Combine current word with each sub-sentence
                foreach (var sentence in subSentences) {
                    // Avoid trailing space for the last word
                    if (sentence == "")
                        result.Add(word);
                    else
                        result.Add(word + " " + sentence);
                }
            }
        }

        // Memoize the result starting at this index
        memo[start] = result;
        return result;
    }
}
