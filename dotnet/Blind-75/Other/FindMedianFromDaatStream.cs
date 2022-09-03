namespace Blind_75.Other;

#nullable disable
// TODO: Heap is not working correctly. Fid easy implementation.
public class MedianFinder
{
    private List<int> _largeHeap, _smallHeap;

    public MedianFinder()
    {
        _largeHeap = new List<int>();
        _smallHeap = new List<int>();

    }
    
    public void AddNum(int num) 
    {
        _smallHeap.Add(num);
        MakeHeapFromBottom(_smallHeap, (current, parent) => current > parent);

        if (_smallHeap.Count - _largeHeap.Count == 2)
        {
            int maxFromSmall = _smallHeap[0];
            Swap(_smallHeap, 0, _smallHeap.Count - 1);
            _smallHeap.RemoveAt(_smallHeap.Count - 1);
            MakeHeapFromTop(_smallHeap, (current, child) => current < child, 0);
            
            _largeHeap.Add(maxFromSmall);
            MakeHeapFromBottom(_largeHeap, (current, parent) => current < parent);
        }
        else
        {
            if (_largeHeap.Any() && _smallHeap[0] > _largeHeap[0])
            {
                (_smallHeap[0], _largeHeap[0]) = (_largeHeap[0], _smallHeap[0]);
                MakeHeapFromTop(_largeHeap, (current, child) => current > child, 0);
            }
        }
    }

    private static void MakeHeapFromBottom(List<int> heap, Func<int, int, bool> swapPredicate)
    {
        int index = heap.Count - 1;
        int parentIndex = (index - 1) / 2;
        while (index > 0 && swapPredicate(heap[index], heap[parentIndex]))
        {
            Swap(heap, index, parentIndex);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private static void MakeHeapFromTop(List<int> heap, Func<int, int, bool> swapPredicate, int index)
    {
        int leftChild = index * 2 + 1;
        int rightChild = index * 2 + 2;

        if (leftChild >= heap.Count)
        {
            return;
        }
        else if (rightChild >= heap.Count)
        {
            if (swapPredicate(heap[index], heap[leftChild]))
            {
                Swap(heap, index, leftChild);
                MakeHeapFromTop(heap, swapPredicate, leftChild);
            }
        }
        else
        {
            int compareWith = swapPredicate(heap[leftChild], heap[rightChild]) ? rightChild : leftChild;
            if (swapPredicate(heap[index], heap[compareWith]))
            {
                Swap(heap, index, compareWith);
                MakeHeapFromTop(heap, swapPredicate, compareWith);
            }
        }
    }

    private static void Swap(List<int> heap, int firstIndex, int secondIndex) =>
        (heap[firstIndex], heap[secondIndex]) = (heap[secondIndex], heap[firstIndex]);

    public double FindMedian()
    {
        if (_largeHeap.Count > _smallHeap.Count)
        {
            return _largeHeap[0];
        }

        if (_smallHeap.Count > _largeHeap.Count)
        {
            return _smallHeap[0];
        }

        if (!_smallHeap.Any())
            throw new InvalidOperationException("No elements added.");

        return (_smallHeap[0] + _largeHeap[0]) / 2.0;
    }
}