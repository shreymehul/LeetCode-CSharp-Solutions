// 392. Is Subsequence
// Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
// A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        int i, j;
        i = j = 0;
        while (i < t.Length && j < s.Length)
        {
            if (t[i].Equals(s[j]))
            {
                j++;
            }
            i++;
        }
        if (j == s.Length)
            return true;
        return false;
    }
}