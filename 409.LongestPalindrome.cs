// 409. Longest Palindrome
// Given a string s which consists of lowercase or uppercase letters, return the length of the longest 
// palindrome that can be built with those letters.

// Letters are case sensitive, for example, "Aa" is not considered a palindrome.

// Example 1:
// Input: s = "abccccdd"
// Output: 7
// Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
// Example 2:
// Input: s = "a"
// Output: 1
// Explanation: The longest palindrome that can be built is "a", whose length is 1.

// Constraints:
// 1 <= s.length <= 2000
// s consists of lowercase and/or uppercase English letters only.
public class Solution {
    public int LongestPalindrome(string s) {
        Dictionary<char, int> freq = new();
        foreach(var c in s){
            if(freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }
        bool odd = false; int size = 0;
        foreach(var item in freq){
            if(item.Value % 2 ==0){
                size += item.Value;
            }
            else
            {
                size += item.Value -1;
                odd = true;
            }
        }
        return odd ? size + 1: size;
    }
}