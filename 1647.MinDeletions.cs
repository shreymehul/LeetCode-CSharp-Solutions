//1647. Minimum Deletions to Make Character Frequencies Unique

// A string s is called good if there are no two different characters in s that have the same frequency.
// Given a string s, return the minimum number of characters you need to delete to make s good.
// The frequency of a character in a string is the number of times it appears in the string. For example, in the string "aab", the frequency of 'a' is 2, while the frequency of 'b' is 1.

public class Solution {
    public int MinDeletions(string s) {
        int[] freq = new int[26];
        int maxFreq = 0;
        for(int i=0; i<s.Length; i++){
            freq[s[i] - 'a']++;
            maxFreq = Math.Max(freq[s[i] - 'a'],maxFreq);
        }
        Array.Sort(freq);
        int count = 0;
        for(int i=25; i>=0 && freq[i]>0;i--){
            if(maxFreq > freq[i])
                maxFreq = freq[i];
            else if(maxFreq < freq[i]){
                count += freq[i] - maxFreq;
            }
            maxFreq = Math.Max(0,maxFreq-1);
        }
        return count;
    }
    
}