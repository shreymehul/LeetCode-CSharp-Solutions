// 212. Word Search II
// Given an m x n board of characters and a list of strings words, return all words on the board.

// Each word must be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.

// Example 1:
// Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
// Output: ["eat","oath"]
// Example 2:
// Input: board = [["a","b"],["c","d"]], words = ["abcb"]
// Output: []

//DFS with HashMap (TLE)
public class Solution {
    bool[,] visited = new bool[12, 12];
    Dictionary<char, List<int[]>> map = new Dictionary<char, List<int[]>>();
    public  IList<string> FindWords(char[][] board, string[] words)
    {
        IList<string> result = new List<string>();

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (map.ContainsKey(board[row][col]))
                {
                    map[board[row][col]].Add(new int[] { row, col });
                }
                else
                {
                    var tList = new List<int[]>
                    {
                        new int[] { row, col }
                    };
                    map[board[row][col]] = tList;
                }
            }
        }
        foreach (var word in words)
        {
            bool present = Search(board, -1, -1, word, 0);
            if(present)
                result.Add(word);
        }
        return result;
    }
    public bool Search(char[][] board, int r, int c, string word, int idx)
    {
            if (!map.ContainsKey(word[idx]))
                return false;

            foreach (var item in map[word[idx]])
            {
                if (idx == 0 || !visited[item[0], item[1]] && (
                    (item[0] == r+1 && item[1] == c) ||
                    (item[0] == r-1 && item[1] == c) ||
                    (item[0] == r && item[1] == c+1) ||
                    (item[0] == r && item[1] == c-1) ))
                {
                    visited[item[0], item[1]] = true;
                    if (idx + 1 == word.Length || 
                        Search(board, item[0], item[1], word, idx + 1))
                    {
                        visited[item[0], item[1]] = false;
                        return true;
                    }
                    visited[item[0], item[1]] = false;
                }
            }
            return false;
    }
    
}
//Aproch DFS (TLE)
public class Solution {
    bool[,] visited = new bool[12, 12];

    public IList<string> FindWords(char[][] board, string[] words)
    {
        IList<string> result = new List<string>();
        foreach (var word in words)
        {
            bool present = false;
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[0].Length; col++)
                {
                    present = Search(board, row, col, word, 0);
                    if (present)
                    {
                        result.Add(word);
                        break;
                    }
                }
                if (present)
                {
                    break;
                }
            }
        }
        return result;
    }
    public bool Search(char[][] board, int r, int c, string word, int idx)
    {
        if (idx == word.Length)
        {
            return true;
        }
        if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length ||
           visited[r, c] || board[r][c] != word[idx])
            return false;
        visited[r, c] = true;
        bool present =
            Search(board, r+1, c, word, idx + 1) ||
            Search(board, r-1, c, word, idx + 1) ||
            Search(board, r, c+1, word, idx + 1) ||
            Search(board, r, c-1, word, idx + 1);
        visited[r, c] = false;
        return present;
    }
}
//Trie
public class Solution {
    
    public class TrieNode
    {
        public char c;
        public string word;
        public TrieNode[] Children;
        public TrieNode(char c)
        {
            this.c = c;
            this.word = "";
            Children = new TrieNode[26];
        }
    }
    
    public IList<string> FindWords(char[][] board, string[] words) {
        
        List<string> res = new List<string>();
        
        if(board == null || board[0].Length == 0)
            return res;
        
        TrieNode root = new TrieNode('#');
        BuildTrieTree(root, words);
        
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[0].Length; j++)
            {
                if(root.Children[board[i][j] - 'a'] != null)
                    DFS(board, root, i, j, res);
            }
        }
        
        return res;
    }
    
    private void DFS(char[][] board, TrieNode curr, int i, int j, List<string> res)
    {
        if(i < 0 || i >= board.Length || j < 0 || j >= board[0].Length)
            return;
        
        char c = board[i][j];
        if(c == '#' || curr.Children[c - 'a'] == null)
            return;
        curr = curr.Children[c - 'a'];
        if(curr.word != "")
        {
            res.Add(curr.word);
            curr.word = "";
        }
        
        board[i][j] = '#';
        DFS(board, curr, i - 1, j, res);
        DFS(board, curr, i + 1, j, res);
        DFS(board, curr, i, j - 1, res);
        DFS(board, curr, i, j + 1, res);
        board[i][j] = c;
    }
    
    private void BuildTrieTree(TrieNode root, string[] words)
    {
        foreach(string word in words)
        {
            TrieNode curr = root;
            foreach(char c in word)
            {
                if(curr.Children[c - 'a'] == null)
                    curr.Children[c - 'a'] = new TrieNode(c);
                curr = curr.Children[c - 'a'];
            }
            curr.word = word;
        }
    }
}