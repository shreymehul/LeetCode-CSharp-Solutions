//20. Valid Parentheses
//Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
//An input string is valid if:
//Open brackets must be closed by the same type of brackets.
//Open brackets must be closed in the correct order.

public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        if (s.Length % 2 != 0)
            return false;
        stack.Push(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if ((s[i] == '{') || (s[i] == '[') || (s[i] == '('))
            {
                stack.Push(s[i]);
            }
            else if (stack.Count == 0)
                return false;
            else if ((s[i] == '}') && (stack.Peek() == '{'))
            {
                stack.Pop();
            }
            else if ((s[i] == ')') && (stack.Peek() == '('))
            {
                stack.Pop();
            }
            else if ((s[i] == ']') && (stack.Peek() == '['))
            {
                stack.Pop();
            }
            else
                return false;
        }
        if (stack.Count == 0)
            return true;
        return false;
    }
}
