// 146. LRU Cache

// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

// Implement the LRUCache class:

// LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
// int get(int key) Return the value of the key if the key exists, otherwise return -1.
// void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
// The functions get and put must each run in O(1) average time complexity.

// Example 1:
// Input
// ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
// Output
// [null, null, null, 1, null, -1, null, -1, 3, 4]
// Explanation
// LRUCache lRUCache = new LRUCache(2);
// lRUCache.put(1, 1); // cache is {1=1}
// lRUCache.put(2, 2); // cache is {1=1, 2=2}
// lRUCache.get(1);    // return 1
// lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
// lRUCache.get(2);    // returns -1 (not found)
// lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
// lRUCache.get(1);    // return -1 (not found)
// lRUCache.get(3);    // return 3
// lRUCache.get(4);    // return 4

//Using LinkList
public class LRUCache
{
    // Define the capacity of the LRU Cache
    private readonly int capacity;
    
    // Dictionary to store the cache items with key as the integer key and value as the LinkedListNode containing a tuple (key, value)
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    
    // LinkedList to maintain the order of usage, with the most recently used item at the front
    private readonly LinkedList<(int key, int value)> lruList;

    // Constructor to initialize the LRU Cache with a given capacity
    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        lruList = new LinkedList<(int key, int value)>();
    }

    // Method to get the value associated with a key
    public int Get(int key)
    {
        // Check if the key exists in the cache
        if (cache.TryGetValue(key, out LinkedListNode<(int key, int value)> node))
        {
            // If key exists, move the node to the front of the LinkedList (most recently used)
            lruList.Remove(node);
            lruList.AddFirst(node);
            // Return the value associated with the key
            return node.Value.value;
        }
        // If key does not exist, return -1
        return -1; // Key not found
    }

    // Method to put a key-value pair into the cache
    public void Put(int key, int value)
    {
        // Check if the key already exists in the cache
        if (cache.TryGetValue(key, out LinkedListNode<(int key, int value)> node))
        {
            // If key exists, remove the node from its current position
            lruList.Remove(node);
            // Update the value of the node
            node.Value = (key, value);
            // Add the node to the front of the LinkedList (most recently used)
            lruList.AddFirst(node);
        }
        else
        {
            // If key does not exist and cache is at full capacity
            if (cache.Count >= capacity)
            {
                // Remove the least recently used item from the LinkedList and the cache
                var lruNode = lruList.Last;
                lruList.RemoveLast();
                cache.Remove(lruNode.Value.key);
            }
            // Create a new node for the key-value pair
            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            // Add the new node to the front of the LinkedList (most recently used)
            lruList.AddFirst(newNode);
            // Add the new node to the cache
            cache[key] = newNode;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

//self defined DLL
public class LRUCache {
    public class DoublyLinkList
    {
        public (int key, int value) val;
        public DoublyLinkList prev;
        public DoublyLinkList next;
        public DoublyLinkList((int, int) val, DoublyLinkList prev = null,
                            DoublyLinkList next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }
    DoublyLinkList root;
    DoublyLinkList tail;
    Dictionary<int, DoublyLinkList> cache;
    int capacity;
    public LRUCache(int capacity)
    {
        cache = new Dictionary<int, DoublyLinkList>();
        this.capacity = capacity;
        root = tail = null;
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            Remove(cache[key]);
            Add(cache[key]);
            return cache[key].val.value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            Remove(cache[key]);
            cache.Remove(key);
        }
        DoublyLinkList node = new DoublyLinkList((key, value));
        Add(node);
        cache.Add(key, node);
        if(cache.Count == capacity)
        {
            Remove(root);
            cache.Remove(root.val.key);
        }
    }
    public void Add(DoublyLinkList node)
    {
        if (root == null)
        {
            root = node;
            tail = node;
        }
        tail.next = node;
        node.prev = tail;
        tail = node;
    }
    public void Remove(DoublyLinkList node)
    {
        if (root == tail)
            root = tail = null;
        else if(node == root)
        {
            root = root.next;
            root.prev = null;
        }
        else if(node == tail)
        {
            tail = tail.prev;
            tail.next = null;
        }
        else
        {
            DoublyLinkList Prev = node.prev;
            DoublyLinkList Next = node.next;
            if (Prev != null)
                Prev.next = Next;
            if (Next != null)
                Next.prev = Prev;
        }
    }
}
