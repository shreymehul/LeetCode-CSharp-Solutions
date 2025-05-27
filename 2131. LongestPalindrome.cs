// 2131. Longest Palindrome by Concatenating Two Letter Words

// You are given an array of strings words. Each element of words consists of two lowercase English letters.
// Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. 
// Each element can be selected at most once.
// Return the length of the longest palindrome that you can create. If it is impossible to create any palindrome, return 0.
// A palindrome is a string that reads the same forward and backward.

// Example 1:
// Input: words = ["lc","cl","gg"]
// Output: 6
// Explanation: One longest palindrome is "lc" + "gg" + "cl" = "lcggcl", of length 6.
// Note that "clgglc" is another longest palindrome that can be created.
// Example 2:
// Input: words = ["ab","ty","yt","lc","cl","ab"]
// Output: 8
// Explanation: One longest palindrome is "ty" + "lc" + "cl" + "yt" = "tylcclyt", of length 8.
// Note that "lcyttycl" is another longest palindrome that can be created.
// Example 3:
// Input: words = ["cc","ll","xx"]
// Output: 2
// Explanation: One longest palindrome is "cc", of length 2.
// Note that "ll" is another longest palindrome that can be created, and so is "xx".

// Constraints:
// 1 <= words.length <= 105
// words[i].length == 2
// words[i] consists of lowercase English letters.

public class Solution {
    public int LongestPalindrome(string[] words) {
        Dictionary<string, int> dict = new();
        int length = 0;
        bool hasCentral = false;

        foreach (var word in words) {
            string rev = new string(word.Reverse().ToArray());

            if (dict.ContainsKey(rev) && dict[rev] > 0) {
                // Use this pair and its reverse to build a palindrome
                length += 4;
                dict[rev]--;
            }
            else {
                if (!dict.ContainsKey(word)) {
                    dict[word] = 0;
                }
                dict[word]++;
            }
        }

        // Check if any symmetric word (like "aa") can be used in the center
        foreach (var kvp in dict) {
            if (kvp.Key[0] == kvp.Key[1] && kvp.Value > 0) {
                hasCentral = true;
                break;
            }
        }

        if (hasCentral) length += 2;

        return length;
    }
}
