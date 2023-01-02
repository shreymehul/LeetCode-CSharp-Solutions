// 290. Word Pattern
// Given a pattern and a string s, find if s follows the same pattern.
// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
// Example 1:
// Input: pattern = "abba", s = "dog cat cat dog"
// Output: true
// Example 2:
// Input: pattern = "abba", s = "dog cat cat fish"
// Output: false
// Example 3:
// Input: pattern = "aaaa", s = "dog cat cat dog"
// Output: false
// Constraints:
// 1 <= pattern.length <= 300
// pattern contains only lower-case English letters.
// 1 <= s.length <= 3000
// s contains only lowercase English letters and spaces ' '.
// s does not contain any leading or trailing spaces.
// All the words in s are separated by a single space.

public class Solution {
    public bool WordPattern(string pattern, string s) {
        Dictionary <char,string> map1 = new Dictionary<char,string>();
        Dictionary <string,char> map2 = new Dictionary<string,char>();
        string[] sArr = s.Split(" ");
        if(sArr.Length != pattern.Length)
            return false;
        for(int i = 0; i < pattern.Length; i++){
            if(!map1.ContainsKey(pattern[i]) && !map2.ContainsKey(sArr[i])){
                map1[pattern[i]] = sArr[i];
                map2[sArr[i]] = pattern[i];
            }
            else if(map1.ContainsKey(pattern[i]) && map1[pattern[i]] == sArr[i]
                && map2.ContainsKey(sArr[i]) && map2[sArr[i]] == pattern[i])
                continue;
            else
                return false;
        }
        return true;
    }
}