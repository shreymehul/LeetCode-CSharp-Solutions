// 676. Implement Magic Dictionary
// Design a data structure that is initialized with a list of different words. Provided a string, you should determine if you can change exactly one character in this string to match any word in the data structure.
// Implement the MagicDictionary class:
// MagicDictionary() Initializes the object.
// void buildDict(String[] dictionary) Sets the data structure with an array of distinct strings dictionary.
// bool search(String searchWord) Returns true if you can change exactly one character in searchWord to match any string in the data structure, otherwise returns false.

// Example 1:
// Input
// ["MagicDictionary", "buildDict", "search", "search", "search", "search"]
// [[], [["hello", "leetcode"]], ["hello"], ["hhllo"], ["hell"], ["leetcoded"]]
// Output
// [null, null, false, true, false, false]
// Explanation
// MagicDictionary magicDictionary = new MagicDictionary();
// magicDictionary.buildDict(["hello", "leetcode"]);
// magicDictionary.search("hello"); // return False
// magicDictionary.search("hhllo"); // We can change the second 'h' to 'e' to match "hello" so we return True
// magicDictionary.search("hell"); // return False
// magicDictionary.search("leetcoded"); // return False

// Constraints:
// 1 <= dictionary.length <= 100
// 1 <= dictionary[i].length <= 100
// dictionary[i] consists of only lower-case English letters.
// All the strings in dictionary are distinct.
// 1 <= searchWord.length <= 100
// searchWord consists of only lower-case English letters.
// buildDict will be called only once before search.
// At most 100 calls will be made to search.

public class MagicDictionary {
    private MagicDictionary[] children;
    private bool isEnd;

    public MagicDictionary() {
        children = new MagicDictionary[26];
        isEnd = false;
    }

    public void BuildDict(string[] dictionary) {
        foreach (var word in dictionary) {
            MagicDictionary node = this;
            foreach (char ch in word) {
                if (node.children[ch - 'a'] == null) {
                    node.children[ch - 'a'] = new MagicDictionary();
                }
                node = node.children[ch - 'a'];
            }
            node.isEnd = true;
        }
    }

    public bool Search(string searchWord) {
        return SearchHelper(this, searchWord, 0, false);
    }

    private bool SearchHelper(MagicDictionary node, string word, int index, bool modified) {
        if (index == word.Length) {
            return modified && node.isEnd;
        }

        char ch = word[index];
        int idx = ch - 'a';

        if (node.children[idx] != null) {
            if (SearchHelper(node.children[idx], word, index + 1, modified)) {
                return true;
            }
        }

        if (!modified) {
            for (int i = 0; i < 26; i++) {
                if (i != idx && node.children[i] != null) {
                    if (SearchHelper(node.children[i], word, index + 1, true)) {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dictionary);
 * bool param_2 = obj.Search(searchWord);
 */
