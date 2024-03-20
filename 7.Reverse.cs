// 7. Reverse Integer
// Given a signed 32-bit integer x, return x with its digits reversed. 
// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], 
// then return 0.
// Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

// Example 1:
// Input: x = 123
// Output: 321
// Example 2:
// Input: x = -123
// Output: -321
// Example 3:
// Input: x = 120
// Output: 21

// Constraints:
// -231 <= x <= 231 - 1

public class Solution {
    public int Reverse(int x) {
        var str = x.ToString();
        string reversed = "";
        bool isNegative = false;
        //Check if the number is negative
        if (str[0] == '-') 
            isNegative = true;
        //Reverse the string
        //If the number is negative, we don't reverse the first character
        for (int i = str.Length-1; i >= 0; i--) {
            if (isNegative && i == 0)
                break;
            else
                reversed += str[i];
        }
        var result = (isNegative)?$"-{reversed}":reversed;
        
        long retValue = Convert.ToInt64(result);
        if (retValue >= Int32.MaxValue || retValue <= Int32.MinValue)
            retValue = 0;
        
        return (int)retValue;
    }
}