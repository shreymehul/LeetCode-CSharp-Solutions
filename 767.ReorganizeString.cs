// 767. Reorganize String

// Given a string s, rearrange the characters of s so that any two adjacent characters are not the same.

// Return any possible rearrangement of s or return "" if not possible.

// Example 1:

// Input: s = "aab"
// Output: "aba"
// Example 2:

// Input: s = "aaab"
// Output: ""

public class Solution {
    public string ReorganizeString(string s) {
        int[] freq = new int[26];
        foreach(char c in s)
            freq[c - 'a']++;
        PriorityQueue<(char,int),int> maxHeap = new PriorityQueue<(char,int),int>();
        for(int i = 0; i < 26; i++){
            if(freq[i] > (s.Length +1) /2 )
                return "";
            if(freq[i] > 0)
                maxHeap.Enqueue(((char)('a' + i),freq[i]), -1* freq[i]);
        }
        char[] res = new char[s.Length];
        for(int i = 0; i < s.Length; i++)
            res[i] = '_';
        int idx = 0;
            while (maxHeap.Count > 0)
            {
                char c = maxHeap.Peek().Item1;
                int f = maxHeap.Dequeue().Item2;
                while (f > 0)
                {
                    if (idx >= res.Length)
                        idx = 1;
                    // if (res[idx] == '_')
                    // {
                        res[idx] = c;
                        idx += 2;
                        f--;
                    // }
                    // else
                    // {
                    //    idx++;
                    // }
                }
            }
        return new String(res);
    }
}