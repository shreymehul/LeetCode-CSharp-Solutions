// 7. Reverse Integer
// Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
// Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

public class Solution {
    public int Reverse(int x) {
        var str = x.ToString();
        string reversed = "";
        bool isNegative = false;
        
        if (str[0] == '-') 
            isNegative = true;
        
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