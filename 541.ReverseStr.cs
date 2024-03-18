// 541. Reverse String II
// Given a string s and an integer k, reverse the first k characters for every 2k characters counting 
// from the start of the string.

// If there are fewer than k characters left, reverse all of them. 
// If there are less than 2k but greater than or equal to k characters, then reverse the first k 
// characters and leave the other as original.

// Example 1:
// Input: s = "abcdefg", k = 2
// Output: "bacdfeg"
// Example 2:
// Input: s = "abcd", k = 2
// Output: "bacd"
 
// Constraints:
// 1 <= s.length <= 104
// s consists of only lowercase English letters.
// 1 <= k <= 104

public class Solution {
    public string ReverseStr(string s, int k) {
        char[] arr = s.ToCharArray();
        //intution: reverse the first k characters for every 2k characters counting from the start of the string.
        //incrementing i by 2*k because we need to reverse the first k characters for every 2k characters
        for (int i = 0; i < arr.Length; i += 2 * k) {
            int left = i;
            int right = Math.Min(i + k - 1, arr.Length - 1);
            while (left < right) {
                (arr[left], arr[right]) = ((arr[right], arr[left]));
                left++;
                right--;
            }
        }
        return new string(arr);
    }
}