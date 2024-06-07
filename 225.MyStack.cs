// 225. Implement Stack using Queues
// Implement a last-in-first-out (LIFO) stack using only two queues. The implemented stack should support all the functions of a normal stack (push, top, pop, and empty).

// Implement the MyStack class:

// void push(int x) Pushes element x to the top of the stack.
// int pop() Removes the element on the top of the stack and returns it.
// int top() Returns the element on the top of the stack.
// boolean empty() Returns true if the stack is empty, false otherwise.
// Notes:
// You must use only standard operations of a queue, which means that only push to back, peek/pop from front, size and is empty operations are valid.
// Depending on your language, the queue may not be supported natively. You may simulate a queue using a list or deque (double-ended queue) as long as you use only a queue's standard operations.
 

// Example 1:
// Input
// ["MyStack", "push", "push", "top", "pop", "empty"]
// [[], [1], [2], [], [], []]
// Output
// [null, null, null, 2, 2, false]

// Explanation
// MyStack myStack = new MyStack();
// myStack.push(1);
// myStack.push(2);
// myStack.top(); // return 2
// myStack.pop(); // return 2
// myStack.empty(); // return False

// Constraints:
// 1 <= x <= 9
// At most 100 calls will be made to push, pop, top, and empty.
// All the calls to pop and top are valid.

public class MyStack {
    Queue<int> first;
    Queue<int> second;
    public MyStack() {
        first = new();
        second = new();
    }
    
    public void Push(int x) {
        first.Enqueue(x);
    }
    
    public int Pop() {
        while(first.Count > 1){
            second.Enqueue(first.Dequeue());
        }
        int result = first.Dequeue();
        while(second.Any()){
            first.Enqueue(second.Dequeue());
        }
        return result;
    }
    
    public int Top() {
        int result = -1;
        while(first.Count > 0){
            result = first.Dequeue();
            second.Enqueue(result);
        }
        while(second.Any()){
            first.Enqueue(second.Dequeue());
        }
        return result;
    }
    
    public bool Empty() {
        return !first.Any();
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */


 public class MyStack {
    Queue<int> first;
    Queue<int> second;
    public MyStack() {
        first = new();
        second = new();
    }
    
    public void Push(int x) {
        var currQueue = second.Any() ? second : first;
        currQueue.Enqueue(x);
    }
    
    public int Pop() {
        Queue<int> currQueue;
        Queue<int> nextQueue;
        if(second.Any()){
            currQueue = second;
            nextQueue = first;
        }
        else{
            nextQueue = second;
            currQueue = first;
        }
        while(currQueue.Count > 1){
            nextQueue.Enqueue(currQueue.Dequeue());
        }
        int result = currQueue.Dequeue();
        return result;
    }
    
    public int Top() {
        int result = -1;
        Queue<int> currQueue;
        Queue<int> nextQueue;
        if(second.Any()){
            currQueue = second;
            nextQueue = first;
        }
        else{
            nextQueue = second;
            currQueue = first;
        }
        while(currQueue.Count > 0){
            result = currQueue.Dequeue();
            nextQueue.Enqueue(result);
        }
        return result;
    
    }
    
    public bool Empty() {
        return !first.Any() && !second.Any();
    }
}
