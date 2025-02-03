//14. Longest Common Prefix
//Write a function to find the longest common prefix string amongst an array of strings.
//If there is no common prefix, return an empty string "".

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        int size = strs.Length;
        if (size == 0)
            return "";
        if (size == 1)
            return strs[0];
        //Sort the array of strings
        //The first and last strings will be the smallest and largest strings
        //We can compare the first and last strings to find the longest common prefix
        Array.Sort(strs);
        int end = Math.Min(strs[0].Length, strs[size - 1].Length);
        int i = 0;
        while (i < end && strs[0][i] == strs[size - 1][i])
            i++;
        String pre = strs[0].Substring(0, i);
        return pre;
    }
}

//Trie
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return "";

        Trie root = new();
        foreach (var word in strs)
            root.Insert(word);

        return root.LongestPrefix();
    }

    public class Trie
    {
        private bool isEndOfWord;
        private readonly Dictionary<char, Trie> children;

        public Trie()
        {
            children = new Dictionary<char, Trie>();
            isEndOfWord = false;
        }

        public void Insert(string word)
        {
            var current = this;
            foreach (char c in word)
            {
                if (!current.children.ContainsKey(c))
                    current.children[c] = new Trie();

                current = current.children[c];
            }
            current.isEndOfWord = true;
        }

        public string LongestPrefix()
        {
            var prefix = new System.Text.StringBuilder();
            var current = this;

            while (current.children.Count == 1 && !current.isEndOfWord)
            {
                foreach (var child in current.children) // Always 1 child
                {
                    prefix.Append(child.Key);
                    current = child.Value;
                }
            }
            return prefix.ToString();
        }
    }
}
