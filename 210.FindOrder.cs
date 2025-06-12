// 210. Course Schedule II

// There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
// You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if
// you want to take course ai.

// For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
// Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them.
// If it is impossible to finish all courses, return an empty array.

// Example 1:
// Input: numCourses = 2, prerequisites = [[1,0]]
// Output: [0,1]
// Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
// Example 2:
// Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
// Output: [0,2,1,3]
// Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
// So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
// Example 3:
// Input: numCourses = 1, prerequisites = []
// Output: [0]

//Detect Cycle  & Reverse Topological Sort
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // Adjacency list for graph representation
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }

        // Build the graph: prereq → course
        foreach (var pair in prerequisites) {
            int course = pair[0];
            int prereq = pair[1];
            graph[course].Add(prereq);
        }

        int[] state = new int[numCourses];  // 0 = unvisited, 1 = visited, 2 = visiting
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < numCourses; i++) {
            if (state[i] == 0) {
                if (HasCycle(i, graph, state, stack)) {
                    return new int[0]; // Return empty if a cycle is found
                }
            }
        }

        // Reverse the stack to get correct course order
        return stack.Reverse().ToArray();
    }

    private bool HasCycle(int node, List<int>[] graph, int[] state, Stack<int> stack) {
        if (state[node] == 2) return true;   // Cycle detected
        if (state[node] == 1) return false;  // Already visited

        state[node] = 2; // Mark as visiting

        foreach (var neighbor in graph[node]) {
            if (HasCycle(neighbor, graph, state, stack)) {
                return true;
            }
        }

        state[node] = 1;     // Mark as visited
        stack.Push(node);    // Post-order push
        return false;
    }
}
