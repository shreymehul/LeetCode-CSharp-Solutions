// 58. Length of Last Word
// Given a string s consisting of some words separated by some number of spaces, return the length of the last word in 
// the string.
// A word is a maximal substring consisting of non-space characters only.

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int count = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (count == 0 && s[i].Equals(' '))
                continue;
            else if (count != 0 && s[i].Equals(' '))
                break;
            count++;
        }
        return count;
    }
}