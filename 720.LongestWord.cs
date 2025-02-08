// 720. Longest Word in Dictionary
// Given an array of strings words representing an English Dictionary, return the longest word in words that can be built one
// character at a time by other words in words.
// If there is more than one possible answer, return the longest word with the smallest lexicographical order. 
// If there is no answer, return the empty string.
// Note that the word should be built from left to right with each additional character being added to the end of a previous word. 

// Example 1:

// Input: words = ["w","wo","wor","worl","world"]
// Output: "world"
// Explanation: The word "world" can be built one character at a time by "w", "wo", "wor", and "worl".

// Example 2:
// Input: words = ["a","banana","app","appl","ap","apply","apple"]
// Output: "apple"
// Explanation: Both "apply" and "apple" can be built from other words in the dictionary. However, "apple" is lexicographically 
// smaller than "apply".

// Constraints:
// 1 <= words.length <= 1000
// 1 <= words[i].length <= 30
// words[i] consists of lowercase English letters.

public class Solution
{
    public string LongestWord(string[] words)
    {
        // Sort by length, then lexicographically for ties
        Array.Sort(words, (a, b) => a.Length != b.Length ? 
                        a.Length - b.Length : string.Compare(a, b));

        var wordMap = new Dictionary<string, bool>();
        string result = "";

        foreach (var word in words)
        {
            if (word.Length == 1 || 
                    (wordMap.ContainsKey(word.Substring(0, word.Length - 1)) 
                        && wordMap[word.Substring(0, word.Length - 1)]))
            {
                wordMap[word] = true;

                if (word.Length > result.Length || 
                    (word.Length == result.Length 
                            && string.Compare(word, result) < 0))
                {
                    result = word;
                }
            }
            else
            {
                wordMap[word] = false;
            }
        }

        return result;
    }
}


public class Solution
{
    public string LongestWord(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        string result = "";

        foreach (var word in words)
        {
            if (IsValidBuildableWord(word, wordSet))
            {
                // Select longest word or smallest lexicographically for ties
                if (word.Length > result.Length || 
                    (word.Length == result.Length 
                            && string.Compare(word, result) < 0))
                {
                    result = word;
                }
            }
        }

        return result;
    }

    private bool IsValidBuildableWord(string word, HashSet<string> wordSet)
    {
        for (int i = 1; i < word.Length; i++)
        {
            if (!wordSet.Contains(word.Substring(0, i)))
            {
                return false;
            }
        }
        return true;
    }
}