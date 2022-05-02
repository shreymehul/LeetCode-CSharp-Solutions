// 125. Valid Palindrome
// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
// Given a string s, return true if it is a palindrome, or false otherwise.
public class Solution
{
    public bool IsPalindrome(string s)
    {
        Regex rgx = new Regex("[^a-zA-Z]");
        s = rgx.Replace(s, "").ToLower();
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return s.Equals(new string(charArray));
    }
}

public class Solution
{
    public bool IsPalindrome(string s)
    {
        List<char> strArr = new List<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z') ||
                (s[i] >= '0' && s[i] <= '9'))
                strArr.Add(Char.ToLower(s[i]));
        }
        List<char> revStrArr = Enumerable.Reverse(strArr).ToList();
        return (new string(strArr.ToArray())).Equals(new string(revStrArr.ToArray()));
    }
}