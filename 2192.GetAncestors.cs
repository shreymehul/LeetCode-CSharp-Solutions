// 2192. All Ancestors of a Node in a Directed Acyclic Graph
// You are given a positive integer n representing the number of nodes of a Directed Acyclic Graph (DAG). The nodes are numbered from 0 to n - 1 (inclusive).
// You are also given a 2D integer array edges, where edges[i] = [fromi, toi] denotes that there is a unidirectional edge from fromi to toi in the graph.
// Return a list answer, where answer[i] is the list of ancestors of the ith node, sorted in ascending order.
// A node u is an ancestor of another node v if u can reach v via a set of edges.

// Example 1:
// Input: n = 8, edgeList = [[0,3],[0,4],[1,3],[2,4],[2,7],[3,5],[3,6],[3,7],[4,6]]
// Output: [[],[],[],[0,1],[0,2],[0,1,3],[0,1,2,3,4],[0,1,2,3]]
// Explanation:
// The above diagram represents the input graph.
// - Nodes 0, 1, and 2 do not have any ancestors.
// - Node 3 has two ancestors 0 and 1.
// - Node 4 has two ancestors 0 and 2.
// - Node 5 has three ancestors 0, 1, and 3.
// - Node 6 has five ancestors 0, 1, 2, 3, and 4.
// - Node 7 has four ancestors 0, 1, 2, and 3.
// Example 2:
// Input: n = 5, edgeList = [[0,1],[0,2],[0,3],[0,4],[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
// Output: [[],[0],[0,1],[0,1,2],[0,1,2,3]]
// Explanation:
// The above diagram represents the input graph.
// - Node 0 does not have any ancestor.
// - Node 1 has one ancestor 0.
// - Node 2 has two ancestors 0 and 1.
// - Node 3 has three ancestors 0, 1, and 2.
// - Node 4 has four ancestors 0, 1, 2, and 3.

// Constraints:
// 1 <= n <= 1000
// 0 <= edges.length <= min(2000, n * (n - 1) / 2)
// edges[i].length == 2
// 0 <= fromi, toi <= n - 1
// fromi != toi
// There are no duplicate edges.
// The graph is directed and acyclic.

public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        List<IList<int>> ancestors = new List<IList<int>>(new List<int>[n]);
        List<IList<int>> adjacency = new List<IList<int>>(new List<int>[n]);
        for (int i = 0; i < n; i++) {
            adjacency[i] = new List<int>();
            ancestors[i] = new List<int>();
        }
        
        //Reverse from child to parrent
        foreach (var edge in edges) {
            adjacency[edge[1]].Add(edge[0]);
        }
        
        Dictionary<int, HashSet<int>> memo = new Dictionary<int, HashSet<int>>();
        
        for (int i = 0; i < n; i++) {
            var visited = FindAncestors(adjacency, memo, i);
            foreach (var ancestor in visited) {
                if (i != ancestor) {
                    ancestors[i].Add(ancestor);
                }
            }
            var sortedAncestors = ancestors[i].ToList();
            sortedAncestors.Sort();
            ancestors[i] = sortedAncestors;
        }
        
        return ancestors;
    }
    
    private HashSet<int> FindAncestors(List<IList<int>> adjacency, Dictionary<int, HashSet<int>> memo, int node) {
        if (memo.ContainsKey(node)) {
            return memo[node];
        }
        
        var visited = new HashSet<int>();
        foreach (var ancestor in adjacency[node]) {
            visited.Add(ancestor);
            visited.UnionWith(FindAncestors(adjacency, memo, ancestor));
        }
        
        memo[node] = visited;
        return visited;
    }
}


//Approch 2
public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        List<IList<int>> ancestors = new List<IList<int>>();
        List<IList<int>> adjacency = new List<IList<int>>();
        for(int i = 0; i < n; i++){
            adjacency.Add(new List<int>());
        }
        foreach(var edge in edges){
            adjacency[edge[1]].Add(edge[0]);
        }
        for(int i = 0; i < n; i++){
            List<int> ancestor = new();
            HashSet<int> visited = new();
            FindChildren(adjacency, visited, i);
            for(int j = 0; j < n; j++)
                if(visited.Contains(j) && i !=j)
                    ancestor.Add(j);
            ancestors.Add(ancestor);
        }
        return ancestors;
    }
    private void FindChildren(List<IList<int>> adjacency, HashSet<int> visited, int currNode){
        visited.Add(currNode);
        foreach(int nbr in adjacency[currNode]){
            if(!visited.Contains(nbr))
                FindChildren(adjacency, visited, nbr);
        }
    }
}