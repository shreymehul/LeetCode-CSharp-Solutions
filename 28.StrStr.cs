// 28. Implement strStr()
// Implement strStr().
// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        for (int i = 0; i <= (haystack.Length - needle.Length); i++)
        {
            string str = haystack.Substring(i, needle.Length);
            if (String.Equals(str, needle))
            {
                return i;
            }
        }
        return -1;
    }
}