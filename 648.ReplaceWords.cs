// 648. Replace Words
// In English, we have a concept called root, which can be followed by some other word to form another longer word - let's call this word derivative. For example, when the root "help" is followed by the word "ful", we can form a derivative "helpful".
// Given a dictionary consisting of many roots and a sentence consisting of words separated by spaces, replace all the derivatives in the sentence with the root forming it. If a derivative can be replaced by more than one root, replace it with the root that has the shortest length.
// Return the sentence after the replacement.

// Example 1:
// Input: dictionary = ["cat","bat","rat"], sentence = "the cattle was rattled by the battery"
// Output: "the cat was rat by the bat"
// Example 2:
// Input: dictionary = ["a","b","c"], sentence = "aadsfasf absbs bbab cadsfafs"
// Output: "a a b c"

// Constraints:
// 1 <= dictionary.length <= 1000
// 1 <= dictionary[i].length <= 100
// dictionary[i] consists of only lower-case letters.
// 1 <= sentence.length <= 106
// sentence consists of only lower-case letters and spaces.
// The number of words in sentence is in the range [1, 1000]
// The length of each word in sentence is in the range [1, 1000]
// Every two consecutive words in sentence will be separated by exactly one space.
// sentence does not have leading or trailing spaces.

//Trie
public class Solution {
    Trie root = new Trie();
    
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        InsertPrefix(dictionary);
        return Convert(sentence);
    }

    public void InsertPrefix(IList<string> dictionary) {
        foreach (var word in dictionary) {
            Trie node = root;
            foreach (var ch in word) {
                if (!node.Contains(ch))
                    node.Insert(ch);
                node = node.child[ch - 'a'];
            }
            node.SetEnd();
        }
    }

    public string Convert(string sentence) {
        List<string> words = sentence.Split(" ").ToList();
        StringBuilder result = new StringBuilder();
        
        foreach (var word in words) {
            StringBuilder prefix = new StringBuilder();
            Trie node = root;
            bool found = false;
            
            foreach (var ch in word) {
                if (node.Contains(ch)) {
                    prefix.Append(ch);
                    node = node.child[ch - 'a'];
                    if (node.IsEnd()) {
                        found = true;
                        break;
                    }
                } else {
                    break;
                }
            }
            
            if (found) {
                result.Append(prefix);
            } else {
                result.Append(word);
            }
            result.Append(" ");
        }
        
        // Remove the extra space at the end
        if (result.Length > 0) {
            result.Length--;
        }
        
        return result.ToString();
    }

    public class Trie {
        public Trie[] child;
        bool isEnd;
        
        public Trie() {
            child = new Trie[26];
            isEnd = false;
        }
        
        public void Insert(char ch) {
            child[ch - 'a'] = new Trie();
        }
        
        public bool Contains(char ch) {
            return child[ch - 'a'] != null;
        }
        
        public bool IsEnd() {
            return isEnd;
        }
        
        public void SetEnd() {
            isEnd = true;
        }
    }
}


//HashSet
public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        StringBuilder word = new StringBuilder("");
        HashSet<string> wordSet = new HashSet<string>(dictionary);
        StringBuilder result  = new StringBuilder("");;
        for(int c = 0; c < sentence.Length; c++){
            if(sentence[c] != ' '){
                word.Append(sentence[c]);
                if(wordSet.Contains(word.ToString())){
                    while(c+1 < sentence.Length && sentence[c+1] != ' '){
                        c++;
                    }
                }
            }
            else{
                if(word.Length > 0){
                    result.Append(word);
                    word = new StringBuilder("");
                }
                result.Append(sentence[c]);
            }
        }
        if(word.Length > 0){
            result.Append(word);
        }
        return result.ToString();
    }
}


//Linq
public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        return string.Join(" ", 
            sentence.Split()
                .Select(w => dictionary
                    .Where(d => d.Length <= w.Length && w[..d.Length].Equals(d))
                    .MinBy(x => x.Length) ?? w)
            );
    }
}