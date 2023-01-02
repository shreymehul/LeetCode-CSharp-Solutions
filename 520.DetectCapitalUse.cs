// 520. Detect Capital
// We define the usage of capitals in a word to be right when one of the following cases holds:
// All letters in this word are capitals, like "USA".
// All letters in this word are not capitals, like "leetcode".
// Only the first letter in this word is capital, like "Google".
// Given a string word, return true if the usage of capitals in it is right.
// Example 1:
// Input: word = "USA"
// Output: true
// Example 2:
// Input: word = "FlaG"
// Output: false
// Constraints:
// 1 <= word.length <= 100
// word consists of lowercase and uppercase English letters.

public class Solution {
    public bool DetectCapitalUse(string word) {
        bool flag = false;
        for(int i = 0; i < word.Length; i++){
            if(i == 0){
                if(word[i] >= 'A' && word[i] <= 'Z')
                    flag = true;
                else
                    flag = false;
            }
            else if(i == 1){
                if(flag && word[i] >= 'a' && word[i] <= 'z')
                    flag = false;
                else if(flag && word[i] >= 'A' && word[i] <= 'Z')
                    continue;
                else if(!flag && word[i] >= 'a' && word[i] <= 'z')
                    continue;
                else 
                    return false;
            }
            else{
                if(flag && word[i] >= 'A' && word[i] <= 'Z')
                    continue;
                else if(!flag && word[i] >= 'a' && word[i] <= 'z')
                    continue;
                else 
                    return false;
            }
        }
        return true;
    }
}