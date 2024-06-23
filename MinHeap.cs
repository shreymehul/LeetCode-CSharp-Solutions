using System;

public class MinHeap
{
    private int[] heap;
    private int size;
    private int capacity;

    public MinHeap(int capacity)
    {
        this.capacity = capacity;
        this.size = 0;
        this.heap = new int[capacity];
    }

    private int GetLeftChildIndex(int index) => 2 * index + 1;
    private int GetRightChildIndex(int index) => 2 * index + 2;
    private int GetParentIndex(int index) => (index - 1) / 2;

    private bool HasLeftChild(int index) => GetLeftChildIndex(index) < size;
    private bool HasRightChild(int index) => GetRightChildIndex(index) < size;
    private bool HasParent(int index) => GetParentIndex(index) >= 0;

    private int LeftChild(int index) => heap[GetLeftChildIndex(index)];
    private int RightChild(int index) => heap[GetRightChildIndex(index)];
    private int Parent(int index) => heap[GetParentIndex(index)];

    private void Swap(int indexOne, int indexTwo)
    {
        int temp = heap[indexOne];
        heap[indexOne] = heap[indexTwo];
        heap[indexTwo] = temp;
    }

    public int Peek()
    {
        if (size == 0) throw new InvalidOperationException("Heap is empty");
        return heap[0];
    }

    public void Enqueue(int item)
    {
        EnsureExtraCapacity();
        heap[size] = item;
        size++;
        HeapifyUp();
    }

    public int Dequeue()
    {
        if (size == 0) throw new InvalidOperationException("Heap is empty");
        int item = heap[0];
        heap[0] = heap[size - 1];
        size--;
        HeapifyDown();
        return item;
    }

    private void EnsureExtraCapacity()
    {
        if (size == capacity)
        {
            Array.Resize(ref heap, capacity * 2);
            capacity *= 2;
        }
    }

    private void HeapifyUp()
    {
        int index = size - 1;
        while (HasParent(index) && Parent(index) > heap[index])
        {
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }

    private void HeapifyDown()
    {
        int index = 0;
        while (HasLeftChild(index))
        {
            int smallerChildIndex = GetLeftChildIndex(index);
            if (HasRightChild(index) && RightChild(index) < LeftChild(index))
            {
                smallerChildIndex = GetRightChildIndex(index);
            }

            if (heap[index] < heap[smallerChildIndex])
            {
                break;
            }
            else
            {
                Swap(index, smallerChildIndex);
            }

            index = smallerChildIndex;
        }
    }
}

// Example usage:
public class Program
{
    public static void Main(string[] args)
    {
        MinHeap minHeap = new MinHeap(10);
        minHeap.Enqueue(5);
        minHeap.Enqueue(3);
        minHeap.Enqueue(8);
        minHeap.Enqueue(1);

        Console.WriteLine(minHeap.Peek()); // Output: 1

        Console.WriteLine(minHeap.Dequeue()); // Output: 1
        Console.WriteLine(minHeap.Dequeue()); // Output: 3

        minHeap.Enqueue(2);

        Console.WriteLine(minHeap.Peek()); // Output: 2
    }
}
