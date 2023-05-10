// 242. Valid Anagram

// Given two strings s and t, return true if t is an anagram of s, and false otherwise.

// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all
// the original letters exactly once.

public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length )
            return false;
        for(int i =0; i<s.Length;i++){
            if(t.Contains(s[i])){
                t = t.Remove(t.IndexOf(s[i]),1);
            }
            else 
                return false;
        }
        return true;
        }
}