// 211. Design Add and Search Words Data Structure
// Design a data structure that supports adding new words and finding if a string matches any previously
// added string.

// Implement the WordDictionary class:

// WordDictionary() Initializes the object.
// void addWord(word) Adds word to the data structure, it can be matched later.
// bool search(word) Returns true if there is any string in the data structure that matches word or 
// false otherwise. word may contain dots '.' where dots can be matched with any letter.

// Example:
// Input
// ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
// [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
// Output
// [null,null,null,null,false,true,true,true]
// Explanation
// WordDictionary wordDictionary = new WordDictionary();
// wordDictionary.addWord("bad");
// wordDictionary.addWord("dad");
// wordDictionary.addWord("mad");
// wordDictionary.search("pad"); // return False
// wordDictionary.search("bad"); // return True
// wordDictionary.search(".ad"); // return True
// wordDictionary.search("b.."); // return True

// Constraints:
// 1 <= word.length <= 25
// word in addWord consists of lowercase English letters.
// word in search consist of '.' or lowercase English letters.
// There will be at most 2 dots in word for search queries.
// At most 104 calls will be made to addWord and search.



public class WordDictionary {
    //Intution: We can use Trie data structure to store the words. We can use a recursive function to search the word.
    //If we encounter a '.' in the word, we can recursively search all the children of the current node.
    //If we reach the end of the word, we can check if the current node is a word or not.
    //Time Complexity: O(N) where N is the length of the word
    //Space Complexity: O(N) where N is the length of the word
    public class Trie{
        public Trie[] children = new Trie[26];
        public bool isWord = false;
    }

    Trie root;
    public WordDictionary() {
        root = new Trie();
    }
    
    public void AddWord(string word) {
        Trie node = root;
        foreach (char c in word) {
            int index = c - 'a';
            if (node.children[index] == null) {
                node.children[index] = new Trie();
            }
            node = node.children[index];
        }
        node.isWord = true;
    }
    
    public bool Search(string word) {
        return DfsSearch(root, word, 0);
    }
    private bool DfsSearch(Trie node, string word, int start) {
        if (start == word.Length) {
            return node.isWord;
        }
        char c = word[start];
        if (c == '.') {
            for (int i = 0; i < 26; i++) {
                // if any path is valid, return true
                if (node.children[i] != null && DfsSearch(node.children[i], word, start + 1)) {
                    return true;
                }
            }
            return false;
        } else {
            int index = c - 'a';
            return node.children[index] != null && DfsSearch(node.children[index], word, start + 1);
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */