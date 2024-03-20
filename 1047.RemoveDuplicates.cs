// 1047. Remove All Adjacent Duplicates In String
// You are given a string s consisting of lowercase English letters. 
// A duplicate removal consists of choosing two adjacent and equal letters and removing them.
// We repeatedly make duplicate removals on s until we no longer can.
// Return the final string after all such duplicate removals have been made. 
// It can be proven that the answer is unique.

// Example 1:
// Input: s = "abbaca"
// Output: "ca"
// Explanation: 
// For example, in "abbaca" we could remove "bb" since the letters are adjacent and equal, and this is the only possible move.  The result of this move is that the string is "aaca", of which only "aa" is possible, so the final string is "ca".
// Example 2:
// Input: s = "azxxzy"
// Output: "ay"
 

// Constraints:
// 1 <= s.length <= 105
// s consists of lowercase English letters.

public class Solution {
    //Intuition: Use stack to keep track of the characters. 
    //If the current character is same as the top of the stack, pop the top of the stack. 
    //Else, push the current character to the stack.
    public string RemoveDuplicates(string s) {
        Stack<char> st = new();
        for(int i = 0; i < s.Length; i++){
            if(st.Count() > 0 && st.Peek() == s[i]){
                st.Pop();
            }
            else{
                st.Push(s[i]);
            }
        }
        return new string(st.ToArray().Reverse().ToArray());
    }
}