//  Given a forest ( one or more disconnected trees ), find the root of largest tree
//  and return its Id. If there are multiple such roots, return the smallest Id of them.

//  Complete the largestTree function in the editor below.
//  It has one parameter, immediateParent, which is a map containing key-value pair indicating
//  child -> parent relationship. The key is child and value is the corresponding
//  immediate parent.
//  Constraints
//  - Child cannot have more than one immediate parent.
//  - Parent can have more than one immediate child.
//  - The given key-value pair forms a well-formed forest ( a tree of n nodes will have n-1 edges )

//  Example:

//  Input:
//  { { 1 -> 2 }, { 3 -> 4 } }

//  Expected output: 2
//  Explanation: There are two trees one having root of Id 2 and another having root of Id 4.
//  Both trees have size 2. The smaller number of 2 and 4 is 2. Hence the answer is 2.

//Aproch: Union-Find Structure:

// We maintain a parent dictionary to track the root of each node and a size dictionary to track the size of each tree.
// Union Operation:

// Connect child-parent pairs while merging tree sizes.
// Find Operation:

// Uses path compression to make the structure more efficient.
// Result Selection:

// After merging, the tree with the largest size is selected. In case of ties, the smallest root ID is chosen.


// Complexity Analysis:
// Time Complexity: O(NlogN) due to efficient path compression and union operations.
// Space Complexity: O(N) for the parent and size dictionaries.

using System;
using System.Collections.Generic;

public class Solution
{
    public static int LargestTree(Dictionary<int, int> immediateParent)
    {
        // Step 1: Initialize Union-Find structures
        Dictionary<int, int> parent = new Dictionary<int, int>();
        Dictionary<int, int> size = new Dictionary<int, int>();

        // Initialize each node as its own parent with size 1
        foreach (var kvp in immediateParent)
        {
            int child = kvp.Key, par = kvp.Value;

            if (!parent.ContainsKey(child))
            {
                parent[child] = child;
                size[child] = 1;
            }

            if (!parent.ContainsKey(par))
            {
                parent[par] = par;
                size[par] = 1;
            }

            // Union operation
            Union(child, par, parent, size);
        }

        // Step 2: Find the largest tree size
        int maxSize = 0;
        int resultRoot = int.MaxValue;

        foreach (var node in parent.Keys)
        {
            int root = Find(node, parent);
            if (size[root] > maxSize || (size[root] == maxSize && root < resultRoot))
            {
                maxSize = size[root];
                resultRoot = root;
            }
        }

        return resultRoot;
    }

    private static int Find(int node, Dictionary<int, int> parent)
    {
        if (parent[node] != node)
            parent[node] = Find(parent[node], parent); // Path compression, find ultimate parent
        return parent[node];
    }

    private static void Union(int node1, int node2, Dictionary<int, int> parent, Dictionary<int, int> size)
    {
        int root1 = Find(node1, parent);
        int root2 = Find(node2, parent);

        if (root1 != root2)
        {
            // Union by size
            if (size[root1] < size[root2])
            {
                parent[root1] = root2;
                size[root2] += size[root1];
            }
            else
            {
                parent[root2] = root1;
                size[root1] += size[root2];
            }
        }
    }

    public static void Main(string[] args)
    {
        var input = new Dictionary<int, int> { { 1, 2 }, { 3, 4 } };
        Console.WriteLine(LargestTree(input)); // Expected output: 2
    }
}



//Approch:
// Root Identification:
// Roots are nodes that are never listed as children in the input map.

// Tree Size Calculation:
// A BFS traversal is used to calculate the size of each tree starting from the root.

// Result Selection:
// Select the root of the tree with the largest size.
// In case of ties, select the smallest root ID.

// Complexity Analysis:
// Time Complexity: O(N^2) due to BFS for each root node.
// Space Complexity: O(N) for storing the queue and visited set.

//using System;
//using System.Collections.Generic;

public class Solution
{
    public static int LargestTree(Dictionary<int, int> immediateParent)
    {
        // Step 1: Find all nodes and identify roots
        HashSet<int> allNodes = new HashSet<int>();
        HashSet<int> childNodes = new HashSet<int>();

        foreach (var kvp in immediateParent)
        {
            allNodes.Add(kvp.Key);
            allNodes.Add(kvp.Value);
            childNodes.Add(kvp.Key);
        }

        // Roots will be the nodes that are not children
        List<int> roots = new List<int>();
        foreach (var node in allNodes)
        {
            if (!childNodes.Contains(node))
                roots.Add(node);
        }

        // Step 2: Use BFS to find sizes of each tree
        Dictionary<int, int> treeSizes = new Dictionary<int, int>();
        foreach (var root in roots)
        {
            int size = BFSGetTreeSize(root, immediateParent);
            treeSizes[root] = size;
        }

        // Step 3: Find the root with the largest size
        int maxSize = 0;
        int resultRoot = int.MaxValue;

        foreach (var kvp in treeSizes)
        {
            int root = kvp.Key;
            int size = kvp.Value;

            if (size > maxSize || (size == maxSize && root < resultRoot))
            {
                maxSize = size;
                resultRoot = root;
            }
        }

        return resultRoot;
    }

    private static int BFSGetTreeSize(int root, Dictionary<int, int> immediateParent)
    {
        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        queue.Enqueue(root);
        visited.Add(root);
        int size = 0;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            size++;

            // Explore children
            foreach (var kvp in immediateParent)
            {
                if (kvp.Value == node && !visited.Contains(kvp.Key))
                {
                    queue.Enqueue(kvp.Key);
                    visited.Add(kvp.Key);
                }
            }
        }

        return size;
    }

    public static void Main(string[] args)
    {
        var input = new Dictionary<int, int> { { 1, 2 }, { 3, 4 } };
        Console.WriteLine(LargestTree(input)); // Expected output: 2
    }
}
