// 856. Score of Parentheses

// Given a balanced parentheses string s, return the score of the string.

// The score of a balanced parentheses string is based on the following rule:

// "()" has score 1.
// AB has score A + B, where A and B are balanced parentheses strings.
// (A) has score 2 * A, where A is a balanced parentheses string.
 

// Example 1:

// Input: s = "()"
// Output: 1
// Example 2:

// Input: s = "(())"
// Output: 2

public class Solution {
    public int ScoreOfParentheses(string s) {
        int score=0;
        Stack<int> stack = new Stack<int>();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '('){
            stack.Push(score);
            score = 0;
            }
            else
            {
                score = stack.Pop() + Math.Max(2*score, 1);
            }
        }
        return score;
    }
}