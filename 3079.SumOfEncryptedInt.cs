// 3079. Find the Sum of Encrypted Integers
// You are given an integer array nums containing positive integers. We define a function encrypt such that encrypt(x) replaces every digit in x with the largest digit in x. For example, encrypt(523) = 555 and encrypt(213) = 333.
// Return the sum of encrypted elements.

// Example 1:
// Input: nums = [1,2,3]
// Output: 6
// Explanation: The encrypted elements are [1,2,3]. The sum of encrypted elements is 1 + 2 + 3 == 6.
// Example 2:
// Input: nums = [10,21,31]
// Output: 66
// Explanation: The encrypted elements are [11,22,33]. The sum of encrypted elements is 11 + 22 + 33 == 66.

// Constraints:
// 1 <= nums.length <= 50
// 1 <= nums[i] <= 1000

public class Solution {
    public int SumOfEncryptedInt(int[] nums) {
        int result = 0;
        foreach(var num in nums){
            result += EncryptedInt(num);
        }
        return result;
    }
    private int EncryptedInt(int num){
        int digit = 0, max = 0;
        while(num > 0){
            max = Math.Max(max, num % 10);
            num /= 10;
            digit++;
        }
        while(digit > 0){
            num = num*10 + max;
            digit--;
        }
        return num;
    }
}