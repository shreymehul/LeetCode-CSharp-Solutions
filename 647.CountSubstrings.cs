// 647. Palindromic Substrings

// Given a string s, return the number of palindromic substrings in it.

// A string is a palindrome when it reads the same backward as forward.

// A substring is a contiguous sequence of characters within the string.

public class Solution {
    public int CountSubstrings(string s) {
        bool[,] dp = new bool[s.Length, s.Length];
        Console.WriteLine(dp.Length);
        for (int i = 0; i < s.Length; i++)
        {
            dp[i,i] = true;
        }

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                dp[i,i - 1] = true;
            }
        }

        for (int d = 2; d < s.Length; d++)
        {
            int i = 0; int j = d;
            while (j < s.Length)
            {
                if (s[i] == s[j] && dp[j - 1,i+1])
                    dp[j,i] = true;
                i++;
                j++;
            }
        }
        int count = 0;
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = i; j < dp.GetLength(1); j++)
            {
                if(dp[j,i])
                    count++;
            }
        }
        return count;
    }
}