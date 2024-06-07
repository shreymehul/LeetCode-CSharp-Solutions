// 208. Implement Trie (Prefix Tree)
// A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.

// Implement the Trie class:

// Trie() Initializes the trie object.
// void insert(String word) Inserts the string word into the trie.
// boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
// boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.
 

// Example 1:
// Input
// ["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
// [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
// Output
// [null, null, true, false, true, null, true]
// Explanation
// Trie trie = new Trie();
// trie.insert("apple");
// trie.search("apple");   // return True
// trie.search("app");     // return False
// trie.startsWith("app"); // return True
// trie.insert("app");
// trie.search("app");     // return True

// Constraints:
// 1 <= word.length, prefix.length <= 2000
// word and prefix consist only of lowercase English letters.
// At most 3 * 104 calls in total will be made to insert, search, and startsWith.

//cleaner as per question
public class Trie {
    Trie[] child;
    bool isEnd;
    public Trie() {
        child = new Trie[26];
        isEnd = false;
    }
    
    public void Insert(string word) {
        Trie node = this;
        foreach(char ch in word){
            if(node.child[ch - 'a'] == null){
                node.child[ch - 'a'] = new Trie();
            }
            node = node.child[ch - 'a'];
        }
        node.isEnd = true;
    }
    
    public bool Search(string word) {
        Trie node = this;
        foreach(char ch in word){
            if(node.child[ch - 'a'] == null)
                return false;
            else
                node = node.child[ch -'a'];
        }
        return node.isEnd ;
    }
    
    public bool StartsWith(string prefix) {
        Trie node = this;
        foreach(char ch in prefix){
            if(node.child[ch - 'a'] == null)
                return false;
            else
                node = node.child[ch -'a'];
        }
        return true ;
    }
}

//standard
public class Trie {
    //Time complexity: O(n) where n is the length of the word
    //Space complexity: O(1)
    
    // Initialize the root node
    TrieNode root;
    public Trie() {
        root = new TrieNode();
    }

    // TrieNode class
    public class TrieNode() {
        // Array of TrieNode links for each character in the alphabet
        public TrieNode[] link = new TrieNode[26];
        // Boolean to check if the node is the end of a word
        public bool isEnd = false;

        // Check if the node contains a link for the character
        public bool containsLink(char ch){
            return link[ch - 'a'] != null;
        }

        // Add a link for the character
        public void addLink(char ch){
            link[ch - 'a'] = new TrieNode();
        }

        // Check if the node is the end of a word
        public bool isWordEnd(){
            return isEnd;
        }

        // Set the node as the end of a word
        public void setWordEnd(){
            isEnd = true;
        }
    }
    
    public void Insert(string word) {
        // Start from the root node
        TrieNode node = root;
        foreach(char ch in word){
            // If the node does not contain a link for the character, add a link
            if(!node.containsLink(ch))
                node.addLink(ch);
            // Move to the next node
            node = node.link[ch - 'a'];
        }
        // Set the last node as the end of a word
        node.setWordEnd();
    }
    
    public bool Search(string word) {
        TrieNode node = root;
        // Traverse the trie to find the word
        foreach(char ch in word){
            // If the node does not contain a link for the character, return false
            if(!node.containsLink(ch))
                return false;
            node = node.link[ch - 'a'];
        }
        // Return true if the last node is the end of a word
        return node.isWordEnd();
    }
    
    public bool StartsWith(string prefix) {
        TrieNode node = root;
        // Traverse the trie to find the prefix
        foreach(char ch in prefix){
            // If the node does not contain a link for the character, return false
            if(!node.containsLink(ch))
                return false;
            node = node.link[ch - 'a'];
        }
        // Return true if the prefix is found
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */