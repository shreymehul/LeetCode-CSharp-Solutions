// 32. Longest Valid Parentheses
// Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

// Example 1:
// Input: s = "(()"
// Output: 2
// Explanation: The longest valid parentheses substring is "()".
// Example 2:
// Input: s = ")()())"
// Output: 4
// Explanation: The longest valid parentheses substring is "()()".
// Example 3:
// Input: s = ""
// Output: 0

// Constraints:
// 0 <= s.length <= 3 * 104
// s[i] is '(', or ')'.

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        int maxLength = 0;
        int len = s.Length;
        int count = 0;
        int i = 0;
        char[] ch = s.ToCharArray();
        Stack<int> st = new Stack<int>();
        while (i < len)
        {
            if (st.Count == 0 || ch[i] == '(')
            {
                if (ch[i] == ')')
                {
                    st.Push(-1);
                }
                else
                {
                    st.Push(count);
                }
                count = 0;
            }
            if (ch[i] == ')')
            {
                if (st.Peek() >= 0)
                {
                    count += 2 + st.Pop(); ;
                    maxLength = Math.Max(maxLength, count);
                }
                else
                {
                    st.Push(-1);
                    count = 0;
                }
            }
            i++;
        }

        return maxLength;
    }
}