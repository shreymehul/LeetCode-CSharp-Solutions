public class Solution {
    Stack<int> stack = new Stack<int>();
    int[] Process = new int[2000];
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<int>[] path = new List<int>[numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            path[i] = new List<int>();
        }
        foreach (var item in prerequisites)
        {
            path[item[0]].Add(item[1]);
        }
         
        for (int i = 0; i < numCourses; i++)
        {
            if(Process[i] == 0)
            {
                if (IsCycleAndTopologicalSort(i, path))
                    return new int[0];
            }
        }
        int[] result = new int[numCourses];
        for(int i = numCourses-1; i >=0; i--)
        {
            result[i] = stack.Pop();
        }
        return result;
    }
    public bool IsCycleAndTopologicalSort(int Vertice, List<int>[] path)
    {
        if (Process[Vertice] == 2)
            return true;
        Process[Vertice] = 2;
        foreach (var item in path[Vertice])
        {
            if (Process[item] != 1)
                if (IsCycleAndTopologicalSort(item, path))
                    return true;
        }
        Process[Vertice] = 1;
        stack.Push(Vertice);

        return false;
    }
}