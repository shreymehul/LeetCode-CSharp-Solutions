// 17. Letter Combinations of a Phone Number
// Given a string containing digits from 2-9 inclusive, return all possible letter combinations 
// that the number could represent. Return the answer in any order.
// A mapping of digits to letters (just like on the telephone buttons) is given below. 
// Note that 1 does not map to any letters.
// Example 1:
// Input: digits = "23"
// Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
// Example 2:
// Input: digits = ""
// Output: []
// Example 3:
// Input: digits = "2"
// Output: ["a","b","c"]

public class Solution {
    //Time complexity: O(3^n * 4^m) where n is the number of digits that have 3 letters and m is the number of digits that have 4 letters.
    //Space complexity: O(3^n * 4^m) where n is the number of digits that have 3 letters and m is the number of digits that have 4 letters.
    string[] dialPad = new string[]
        {"","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"};
    public IList<string> LetterCombinations(string digits) {
        IList<string> result = new List<string>();
        if(digits != ""){
            AllCombination(result,digits,"", 0);
        }
        return result;  
    }
    public void AllCombination(IList<string> result,string digits,string s, int idx)    {
        //if last index is checked, add the string to the result list.
        if(idx == digits.Length){
            result.Add(new string(s));
            return;
        }
        //Get the number from the string by converting string to int.
        int num = digits[idx] - '0';
        //Add current character to string s and then call the function recursively for the next digit.
        foreach(char c in dialPad[num]){
            AllCombination(result,digits,s + c, idx+1);
        }
    }
}