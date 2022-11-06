// 705. Design HashSet
// Design a HashSet without using any built-in hash table libraries.
// Implement MyHashSet class:
// void add(key) Inserts the value key into the HashSet.
// bool contains(key) Returns whether the value key exists in the HashSet or not.
// void remove(key) Removes the value key in the HashSet. If key does not exist in the HashSet, do nothing.
// Example 1:

// Input
// ["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"]
// [[], [1], [2], [1], [3], [2], [2], [2], [2]]
// Output
// [null, null, null, true, false, null, true, null, false]
// Explanation
// MyHashSet myHashSet = new MyHashSet();
// myHashSet.add(1);      // set = [1]
// myHashSet.add(2);      // set = [1, 2]
// myHashSet.contains(1); // return True
// myHashSet.contains(3); // return False, (not found)
// myHashSet.add(2);      // set = [1, 2]
// myHashSet.contains(2); // return True
// myHashSet.remove(2);   // set = [1]
// myHashSet.contains(2); // return False, (already removed)

public class MyHashSet {
    bool[] hashSet;
    public MyHashSet() {
        hashSet = new bool[1000001];
    }
    
    public void Add(int key) {
        hashSet[key] = true;
    }
    
    public void Remove(int key) {
        hashSet[key] = false;
    }
    
    public bool Contains(int key) {
        return hashSet[key];
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */

//Approch 2 
 public class MyHashSet {
    bool[,] hashSet;
    public MyHashSet() {
        hashSet = new bool[7,10];
    }
    
    public void Add(int key) {
        int temp = key;
        int i = 0;
        while(temp > 0){
            int setBit = temp % 10;
            hashSet[i,setBit] = true;
            temp = temp/10;
            i++;
        }
    }
    
    public void Remove(int key) {
        int temp = key;
        int i = 0;
        while(temp > 0){
            int setBit = temp % 10;
            hashSet[i,setBit] = false;
            temp = temp/10;
            i++;
        }
    }
    
    public bool Contains(int key) {
        int temp = key;
        int i = 0;
        while(temp > 0){
            int setBit = temp % 10;
            if(!hashSet[i,setBit])
                return false;
            temp = temp/10;
            i++;
        }
        return true;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */