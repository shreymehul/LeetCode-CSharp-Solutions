//20. Valid Parentheses
//Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
//An input string is valid if:
//Open brackets must be closed by the same type of brackets.
//Open brackets must be closed in the correct order.
// Every close bracket has a corresponding open bracket of the same type.
// Example 1:
// Input: s = "()"
// Output: true
// Example 2:
// Input: s = "()[]{}"
// Output: true
// Example 3:
// Input: s = "(]"
// Output: false

// Constraints:
// 1 <= s.length <= 104
// s consists of parentheses only '()[]{}'.

public class Solution
{
    //intution: Use stack to store the opening brackets and pop the stack when a closing bracket is found.
    //If the stack is empty and a closing bracket is found, return false.
    //Time complexity: O(n) where n is the length of the string.
    //Space complexity: O(n) where n is the length of the string.
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
                continue;
            }
            if (stack.Count == 0)
                return false;
            if ((s[i] == '}') && (stack.Peek() == '{'))
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
