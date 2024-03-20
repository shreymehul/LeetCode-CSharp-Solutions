//14. Longest Common Prefix
//Write a function to find the longest common prefix string amongst an array of strings.
//If there is no common prefix, return an empty string "".

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        int size = strs.Length;
        if (size == 0)
            return "";
        if (size == 1)
            return strs[0];
        //Sort the array of strings
        //The first and last strings will be the smallest and largest strings
        //We can compare the first and last strings to find the longest common prefix
        Array.Sort(strs);
        int end = Math.Min(strs[0].Length, strs[size - 1].Length);
        int i = 0;
        while (i < end && strs[0][i] == strs[size - 1][i])
            i++;
        String pre = strs[0].Substring(0, i);
        return pre;
    }
}
