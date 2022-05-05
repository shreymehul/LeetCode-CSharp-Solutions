// 387. First Unique Character in a String
// Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.

public class Solution
{
    public int FirstUniqChar(string s)
    {
        int[] countAlpha = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            countAlpha[s[i] - 'a']++;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (countAlpha[s[i] - 'a'] == 1)
                return i;
        }
        return -1;
    }
}