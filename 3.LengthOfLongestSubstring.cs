// 3. Longest Substring Without Repeating Characters
// Medium

// 28833

// 1229

// Add to List

// Share
// Given a string s, find the length of the longest substring without repeating characters.

 

// Example 1:

// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3.
// Example 2:

// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.
// Example 3:

// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s) )
			return 0;
        int[] freq = new int[95];
        int left,right;
        left = 0;
        right =0;
        int max = 0;
        while(right<s.Length){
            if(freq[s[right] - ' '] == 0){
                freq[s[right] - ' '] ++;
            }
            else{
                while(left < right && freq[s[right] - ' '] !=0){
                    freq[s[left] - ' '] --;
                    left++;
                }
                freq[s[right] - ' '] ++;
            }
            right++;
            max = Math.Max(max, (right-left));
        }
        return max;
    }
}