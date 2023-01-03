// 258. Add Digits
// Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.
// Example 1:
// Input: num = 38
// Output: 2
// Explanation: The process is
// 38 --> 3 + 8 --> 11
// 11 --> 1 + 1 --> 2 
// Since 2 has only one digit, return it.
// Example 2:
// Input: num = 0
// Output: 0

//Time O(1)
public class Solution {
    public int AddDigits(int num) {
       if(num == 0) return 0;
       if(num % 9 == 0) return 9;
       else return num%9;
    }
}

//Approch 2
public class Solution {
    public int AddDigits(int num) {
        int res = 0;
        while(num > 9){
            while(num > 0){
                res += num%10;
                num /= 10;
            }
            num = res;
            res = 0;
        }
        return num;
    }
}