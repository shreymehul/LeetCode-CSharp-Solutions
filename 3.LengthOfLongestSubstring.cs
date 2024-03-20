// 3. Longest Substring Without Repeating Characters
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
    //Intuition: We can solve this problem using two pointers.
    //We can use a frequency array to keep track of the frequency of the characters.
    //We can use two pointers to keep track of the start and end of the substring.
    //We can iterate through the string and keep track of the frequency of the characters.
    //If the frequency of the character is 0, we can increment the frequency and move the right pointer.
    //If the frequency of the character is not 0, we can move the left pointer and decrement the frequency of the character.
    //We can keep track of the maximum length of the substring and return it.
    //Time complexity: O(n)
    //Space complexity: O(1)
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