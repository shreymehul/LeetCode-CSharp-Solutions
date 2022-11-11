// 67. Add Binary
// Given two binary strings a and b, return their sum as a binary string.
// Example 1:
// Input: a = "11", b = "1"
// Output: "100"
// Example 2:
// Input: a = "1010", b = "1011"
// Output: "10101"

public class Solution {
    public string AddBinary(string a, string b) {
        List<char> num = new List<char>();
        int carry = 0;
        int i = a.Length - 1;
        int j = b.Length - 1;
        while (i >= 0 || j >= 0 || carry == 1)
        {
            if (i >= 0) carry += a[i--] - '0';
            if (j >= 0) carry += b[j--] - '0';
            num.Add((char)('0' + (carry % 2)));
            carry /= 2;
        }
        num.Reverse();
        return new string(num.ToArray());
    }
}