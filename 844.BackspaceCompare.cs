// 844. Backspace String Compare
// Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.

// Note that after backspacing an empty text, the text will continue empty.

 

// Example 1:

// Input: s = "ab#c", t = "ad#c"
// Output: true
// Explanation: Both s and t become "ac".
// Example 2:

// Input: s = "ab##", t = "c#d#"
// Output: true
// Explanation: Both s and t become "".
// Example 3:

// Input: s = "a#c", t = "b"
// Output: false
// Explanation: s becomes "c" while t becomes "b".
 

// Constraints:

// 1 <= s.length, t.length <= 200
// s and t only contain lowercase letters and '#' characters.


public class Solution {
    public bool BackspaceCompare(string s, string t) {
        List<char> slist = new();
        List<char> tlist = new();
        
        foreach(char c in s) {
            if(c == '#') {
                if(slist.Count > 0)
                    slist.RemoveAt(slist.Count - 1);
            } else {
                slist.Add(c);
            }
        }
        
        foreach(char c in t) {
            if(c == '#') {
                if(tlist.Count > 0)
                    tlist.RemoveAt(tlist.Count - 1);
            } else {
                tlist.Add(c);
            }
        }
        
        return new string(slist.ToArray()) == new string(tlist.ToArray());
    }
}

public class Solution {
    public bool BackspaceCompare(string s, string t) {
        Stack<char> sStack = new Stack<char>();
        Stack<char> tStack = new Stack<char>();

        foreach (char c in s) {
            if (c == '#') {
                if (sStack.Count > 0) {
                    sStack.Pop();
                }
            } else {
                sStack.Push(c);
            }
        }

        foreach (char c in t) {
            if (c == '#') {
                if (tStack.Count > 0) {
                    tStack.Pop();
                }
            } else {
                tStack.Push(c);
            }
        }

        return sStack.SequenceEqual(tStack);
    }
}


public class Solution {
    public bool BackspaceCompare(string s, string t) {
        int i = s.Length - 1, j = t.Length - 1;
        int skipS = 0, skipT = 0;

        while (i >= 0 || j >= 0) {
            // Process backspaces in s
            while (i >= 0) {
                if (s[i] == '#') {
                    skipS++;
                    i--;
                } else if (skipS > 0) {
                    skipS--;
                    i--;
                } else {
                    break;
                }
            }
            // Process backspaces in t
            while (j >= 0) {
                if (t[j] == '#') {
                    skipT++;
                    j--;
                } else if (skipT > 0) {
                    skipT--;
                    j--;
                } else {
                    break;
                }
            }
            // Compare characters
            if (i >= 0 && j >= 0 && s[i] != t[j]) {
                return false;
            }
            // If one string is exhausted
            if ((i >= 0) != (j >= 0)) {
                return false;
            }
            i--;
            j--;
        }
        return true;
    }
}
