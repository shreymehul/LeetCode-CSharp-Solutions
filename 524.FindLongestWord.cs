// 524. Longest Word in Dictionary through Deleting
// Given a string s and a string array dictionary, return the longest string in the dictionary that can be formed by deleting some of the given string characters. If there is more than one possible result, return the longest word with the smallest lexicographical order. If there is no possible result, return the empty string.

// Example 1:
// Input: s = "abpcplea", dictionary = ["ale","apple","monkey","plea"]
// Output: "apple"

// Example 2:
// Input: s = "abpcplea", dictionary = ["a","b","c"]
// Output: "a"

// Constraints:

// 1 <= s.length <= 1000
// 1 <= dictionary.length <= 1000
// 1 <= dictionary[i].length <= 1000
// s and dictionary[i] consist of lowercase English letters.

public class Solution
{
    public string FindLongestWord(string s, IList<string> dictionary)
    {
        // Sort dictionary by length descending, then lexicographically ascending
        var sortedDict = new List<string>(dictionary);
        sortedDict.Sort((a, b) => b.Length != a.Length ? b.Length - a.Length : string.Compare(a, b));

        foreach (var word in sortedDict)
        {
            if (IsSubsequence(s, word))
            {
                return word; // Return early since the first match is optimal
            }
        }

        return "";
    }

    private bool IsSubsequence(string s, string target)
    {
        int i = 0, j = 0;
        while (i < s.Length && j < target.Length)
        {
            if (s[i] == target[j]) j++;
            i++;
        }
        return j == target.Length;
    }
}


public class Solution
{
    public string FindLongestWord(string s, IList<string> dictionary)
    {
        string result = "";

        foreach (var word in dictionary)
        {
            if (IsSubsequence(s, word))
            {
                // Update result based on length or lexicographical order
                if (word.Length > result.Length || (word.Length == result.Length && string.Compare(word, result) < 0))
                {
                    result = word;
                }
            }
        }

        return result;
    }

    private bool IsSubsequence(string s, string target)
    {
        int i = 0, j = 0;
        
        while (i < s.Length && j < target.Length)
        {
            if (s[i] == target[j]) j++;
            i++;
        }

        return j == target.Length;
    }
}