// 785. Is Graph Bipartite?

// There is an undirected graph with n nodes, where each node is numbered between 0 and n - 1. You are given a 2D array graph, where graph[u] is an array of nodes that node u is adjacent to. More formally, for each v in graph[u], there is an undirected edge between node u and node v. The graph has the following properties:

// There are no self-edges (graph[u] does not contain u).
// There are no parallel edges (graph[u] does not contain duplicate values).
// If v is in graph[u], then u is in graph[v] (the graph is undirected).
// The graph may not be connected, meaning there may be two nodes u and v such that there is no path between them.
// A graph is bipartite if the nodes can be partitioned into two independent sets A and B such that every edge in the graph connects a node in set A and a node in set B.

// Return true if and only if it is bipartite.

public class Solution {
    public bool IsBipartite(int[][] graph)
    {
        int[] visited = new int[graph.Length];
        Array.Fill(visited, -1);
        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == -1)
            {
                bool result = ChkBipar(graph, i, visited);
                if (!result)
                    return false;
            }
        }
        return true;
    }
    class Edge
    {
        public int ed;
        public int level;
        public Edge(int ed, int level)
        {
            this.ed = ed;
            this.level = level;
        }
    }
    public bool ChkBipar(int[][] graph, int src, int[] visited)
    {
        
        Queue<Edge> queue = new Queue<Edge>();
        queue.Enqueue(new Edge(src,0));
        while(queue.Count>0){
            Edge rem = queue.Dequeue();
            if(visited[rem.ed] !=-1){
                if(rem.level != visited[rem.ed])
                    return false;
            }
            else
            {
                visited[rem.ed] = rem.level;
            }
            foreach (var path in graph[rem.ed])
            {
                if (visited[path] == -1)
                    queue.Enqueue(new Edge(path, rem.level + 1));
            }
        }
        return true;
    }
}