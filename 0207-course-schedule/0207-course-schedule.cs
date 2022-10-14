public class Solution {
    int[] Visited = new int[2000];
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] path = new List<int>[numCourses];

        for(int i = 0; i < numCourses; i++)
        {
            path[i] = new List<int>();
        }
        foreach(var item in prerequisites)
        {
            path[item[0]].Add(item[1]);
        }
        for(int i = 0; i < numCourses; i++)
        {
            if (Visited[i] == 0)
            {
                if (IsCycle(i, path))
                    return false;
            }
        }
        return true;
    }
    public bool IsCycle(int Vertice, List<int>[] path)
    {
        if (Visited[Vertice] == 2)
            return true;
        Visited[Vertice] = 2;
        foreach(var item in path[Vertice])
        {
            if (Visited[item] != 1)
                if (IsCycle(item, path))
                    return true;
        }
        Visited[Vertice] = 1;
        return false;
    }
}