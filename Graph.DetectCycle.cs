
// DFS
public class Solution {
    public void DetectCycle(int[][] edges, int n) {
        List[] adj = new List[n];
        foreach(var edge in edges){
            if(adj[edge[0]] == null)
                adj[edge[0]] = new List();
            if(adj[edge[1]] == null)
                adj[edge[1]] = new List();
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }
        Stack<(int, int)> stack = new Stack<(int, int)>();
        HashSet<int> visited = new HashSet<int>();
        while(stack.Count > 0){
            var (node, parent) = stack.Pop();
            visited.Add(node);
            foreach(var neighbor in adj[node]){
                if(visited.Contains(neighbor) && neighbor != parent)
                    return true;
                if(!visited.Contains(neighbor))
                    stack.Push((neighbor, node));
            }
        }
        return false;
    }
}