//438. Find All Anagrams in a String
// Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.


public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        IList<int> res = new List<int>();
        if (p.Length > s.Length)
            return res;
        int[] window = new int[26];
        int[] freq_p = new int[26];
        for(int i = 0;i<p.Length; i++)
        {
            freq_p[p[i] - 'a']++;
            window[s[i] - 'a']++;
        }
        if (IsEqual(window,freq_p))
            res.Add(0);
        for(int i =p.Length; i < s.Length; i++)
        {
            window[s[i] - 'a']++;
            window[s[i-p.Length] - 'a']--;
            if (IsEqual(window, freq_p))
                res.Add(i - p.Length + 1);
        }
        return res;
    }
    public bool IsEqual(int[] a, int[] b)
    {
        for(int i =0; i<a.Length; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }
}