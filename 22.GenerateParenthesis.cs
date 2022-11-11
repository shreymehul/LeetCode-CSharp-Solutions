// 22. Generate Parentheses

// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

// Example 1:
// Input: n = 3
// Output: ["((()))","(()())","(())()","()(())","()()()"]
// Example 2:
// Input: n = 1
// Output: ["()"]

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        FindAll("(",1,0,n,result);
        return result;
    }
    public void FindAll(string s, int cOpen, int cClose, int n, IList<string> result){
        if(cOpen < n){
            FindAll(s+"(",cOpen+1,cClose,n,result);
        }
        if(cClose < cOpen){
            FindAll(s+")",cOpen,cClose+1,n,result);
        }
        if(s.Length == 2*n)
            result.Add(new string(s));
    }
}