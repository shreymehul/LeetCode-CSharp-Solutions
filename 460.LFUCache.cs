// 460. LFU Cache
// Design and implement a data structure for a Least Frequently Used (LFU) cache.

// Implement the LFUCache class:
// LFUCache(int capacity) Initializes the object with the capacity of the data structure.
// int get(int key) Gets the value of the key if the key exists in the cache. Otherwise, returns -1.
// void put(int key, int value) Update the value of the key if present, or inserts the key if not already present. When the cache reaches its capacity, it should invalidate and remove the least frequently used key before inserting a new item. For this problem, when there is a tie (i.e., two or more keys with the same frequency), the least recently used key would be invalidated.
// To determine the least frequently used key, a use counter is maintained for each key in the cache. The key with the smallest use counter is the least frequently used key.

// When a key is first inserted into the cache, its use counter is set to 1 (due to the put operation). The use counter for a key in the cache is incremented either a get or put operation is called on it.
// The functions get and put must each run in O(1) average time complexity.

// Example 1:
// Input
// ["LFUCache", "put", "put", "get", "put", "get", "get", "put", "get", "get", "get"]
// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [3], [4, 4], [1], [3], [4]]
// Output
// [null, null, null, 1, null, -1, 3, null, -1, 3, 4]

// Explanation
// // cnt(x) = the use counter for key x
// // cache=[] will show the last used order for tiebreakers (leftmost element is  most recent)
// LFUCache lfu = new LFUCache(2);
// lfu.put(1, 1);   // cache=[1,_], cnt(1)=1
// lfu.put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
// lfu.get(1);      // return 1
//                  // cache=[1,2], cnt(2)=1, cnt(1)=2
// lfu.put(3, 3);   // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
//                  // cache=[3,1], cnt(3)=1, cnt(1)=2
// lfu.get(2);      // return -1 (not found)
// lfu.get(3);      // return 3
//                  // cache=[3,1], cnt(3)=2, cnt(1)=2
// lfu.put(4, 4);   // Both 1 and 3 have the same cnt, but 1 is LRU, invalidate 1.
//                  // cache=[4,3], cnt(4)=1, cnt(3)=2
// lfu.get(1);      // return -1 (not found)
// lfu.get(3);      // return 3
//                  // cache=[3,4], cnt(4)=1, cnt(3)=3
// lfu.get(4);      // return 4
//                  // cache=[4,3], cnt(4)=2, cnt(3)=3

// Constraints:
// 1 <= capacity <= 104
// 0 <= key <= 105
// 0 <= value <= 109
// At most 2 * 105 calls will be made to get and put.


//---------------
// EXPLANATION
//---------------

// Data Structures:
// mapLeastFrequent: Maps each key to its value and frequency.
// mapLeastRecent: Maps each frequency to a linked list of keys with that frequency.
// keyNodeMap: Maps each key to its corresponding node in the frequency list, enabling O(1) removal.

// Constructor:
// Initializes the cache with the given capacity and sets up the data structures.

// Get Method:
// Checks if the key exists.
// If it exists, updates its frequency and returns its value.
// If it doesn't exist, returns -1.

// Put Method:
// Handles the insertion of a new key-value pair.
// If the cache is full, it removes the least frequently used key.
// Inserts the new key with an initial frequency of 1.

// Update Method:
// Increments the frequency of an existing key.
// Moves the key from its current frequency list to the next frequency list.
// Updates the least frequency if necessary.

// Insert Method:
// Adds a new key or updates an existing key with a given frequency.
// Ensures the frequency list is updated accordingly.

// Remove Method:
// Removes the least frequently used key from the cache.
// Updates the data structures to reflect the removal.

// Complexity:
// Time Complexity:
// Get: O(1), as it involves dictionary lookups and updates.
// Put: O(1), as it involves dictionary lookups, insertions, and removals.
// Space Complexity:
// O(n), where n is the capacity of the cache, as we store up to n key-value pairs and their frequencies.

using System;
using System.Collections.Generic;

public class LFUCache {
    private int capacity;
    private int leastFreq;
    private Dictionary<int, (int value, int freq)> mapLeastFrequent; // Stores key -> (value, frequency)
    private Dictionary<int, LinkedList<int>> mapLeastRecent; // Stores frequency -> list of keys with that frequency
    private Dictionary<int, LinkedListNode<int>> keyNodeMap; // Stores key -> node in the frequency list

    public LFUCache(int capacity) {
        this.capacity = capacity;
        this.leastFreq = 0;
        this.mapLeastFrequent = new Dictionary<int, (int value, int freq)>();
        this.mapLeastRecent = new Dictionary<int, LinkedList<int>>();
        this.keyNodeMap = new Dictionary<int, LinkedListNode<int>>();
    }

    public int Get(int key) {
        // Return -1 if key is not present
        if (!mapLeastFrequent.ContainsKey(key))
            return -1;

        int value = mapLeastFrequent[key].value;
        // Update the frequency of the key
        Update(key, value);
        return value;
    }

    public void Put(int key, int value) {
        if (capacity == 0)
            return;

        if (mapLeastFrequent.ContainsKey(key)) {
            // If key is already present, update its value and frequency
            Update(key, value);
        } else {
            if (mapLeastFrequent.Count == capacity) {
                // If the cache is at capacity, remove the least frequently used key
                Remove();
            }
            // Insert the new key with frequency 1
            Insert(key, value, 1);
        }
    }

    private void Update(int key, int value) {
        int freq = mapLeastFrequent[key].freq;
        // Remove the key from its current frequency list
        mapLeastRecent[freq].Remove(keyNodeMap[key]);

        // If the current frequency list becomes empty, remove it and update leastFreq
        if (mapLeastRecent[freq].Count == 0) {
            mapLeastRecent.Remove(freq);
            if (leastFreq == freq)
                leastFreq++;
        }

        // Insert the key with the updated frequency
        Insert(key, value, freq + 1);
    }

    private void Insert(int key, int value, int freq) {
        // Update the value and frequency of the key
        mapLeastFrequent[key] = (value, freq);

        // Ensure there is a list for the new frequency
        if (!mapLeastRecent.ContainsKey(freq)) {
            mapLeastRecent[freq] = new LinkedList<int>();
        }

        // Add the key to the new frequency list
        mapLeastRecent[freq].AddLast(key);
        keyNodeMap[key] = mapLeastRecent[freq].Last;

        // Update the least frequency
        if (leastFreq > freq) {
            leastFreq = freq;
        } else if (leastFreq == 0) {
            leastFreq = freq;
        }
    }

    private void Remove() {
        // Remove the least frequently used key
        if (!mapLeastRecent.ContainsKey(leastFreq))
            return;

        int key = mapLeastRecent[leastFreq].First.Value;
        mapLeastRecent[leastFreq].RemoveFirst();

        // If the least frequency list becomes empty, remove it
        if (mapLeastRecent[leastFreq].Count == 0) {
            mapLeastRecent.Remove(leastFreq);
        }

        mapLeastFrequent.Remove(key);
        keyNodeMap.Remove(key);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key, value);
 */
