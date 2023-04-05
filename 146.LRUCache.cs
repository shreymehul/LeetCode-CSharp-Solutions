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


//
public class LRUCache {
private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
    private readonly LinkedList<KeyValuePair<int, int>> _lru;

    public LRUCache(int capacity) 
    {
        _capacity = capacity;        
        _cache = new();
        _lru = new();
    }
    
    public int Get(int key) 
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }
        
        _lru.Remove(node);
        _cache[key] = _lru.AddFirst(node.Value);
        
        return node.Value.Value;        
    }
    
    public void Put(int key, int value) 
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _lru.Remove(node);
            _cache.Remove(key);
        }
        
        node = _lru.AddFirst(new KeyValuePair<int, int>(key, value));
        _cache[key] = node;
        
        if (_lru.Count > _capacity)
        {
            node = _lru.Last;            
            _lru.RemoveLast();
            _cache.Remove(node.Value.Key);            
        }
    }
}

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
