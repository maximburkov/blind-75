using System.Security.AccessControl;

namespace Blind_75.LinkedList;

#nullable disable
public class MergeKSortedLists : ISolution
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    private ListNode CreateList(int[] array)
    {
        var dummy = new ListNode();
        var node = dummy;

        foreach (var t in array)
        {
            node.next = new ListNode(t);
            node = node.next;
        }

        return dummy.next;
    }
    
    public void Solve()
    {
        // [[1,4,5],[1,3,4],[2,6]] - working
        
        // [[-8,-7,-7,-5,1,1,3,4],[-2],[-10,-10,-7,0,1,3],[2]] - not working

        var inputArray = new ListNode[]
        {
            CreateList(new[]{-8,-7,-7,-5,1,1,3,4}),
            CreateList(new[]{-2}),
            CreateList(new[]{-10,-10,-7,0,1,3}),
            CreateList(new[]{2})
        };

        var res = MergeKLists(inputArray);

        while (res is not null)
        {
            Console.Write($"{res.val} ");
            res = res.next;
        }
    }
    
    public ListNode MergeKLists(ListNode[] lists)
    {
        List<ListNode> heap = new List<ListNode>(lists.Length);

        foreach (var list in lists)
        {
            if (list is not null)
            {
                heap.Add(list);
                MakeHeapFromBottom(heap);
            }
        }

        ListNode dummyHead = new ListNode();
        ListNode current = dummyHead;
        
        while (heap.Count > 0)
        {
            current.next = new ListNode(ExtractMin(heap));
            current = current.next;
        }

        return dummyHead.next;
    }

    private void MakeHeapFromBottom(List<ListNode> heap)
    {
        int index = heap.Count - 1;
        int parentIndex = (index - 1) / 2;
        while (index > 0 && heap[parentIndex].val > heap[index].val)
        {
            (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private void MakeHeapFromTop(List<ListNode> heap, int index)
    {
        int leftChild = index * 2 + 1;
        int rightChild = index * 2 + 2;

        if (rightChild < heap.Count)
        {
            int minChild = leftChild;
            if (heap[leftChild].val > heap[rightChild].val)
            {
                minChild = rightChild;
            }

            if (heap[minChild].val < heap[index].val)
            {
                (heap[minChild], heap[index]) = (heap[index], heap[minChild]);
                MakeHeapFromTop(heap, minChild);
            }
        }
        else if (leftChild < heap.Count)
        {
            if (heap[leftChild].val < heap[index].val)
            {
                (heap[leftChild], heap[index]) = (heap[index], heap[leftChild]);
            }
        }
    }

    private int ExtractMin(List<ListNode> heap)
    {
        if (heap.Count == 0)
            throw new NotSupportedException("Heap is empty");

        int minimum = heap[0].val;
        heap[0] = heap[0].next;

        if (heap[0] is null)
        {
            (heap[0], heap[^1]) = (heap[^1], heap[0]);
            heap.RemoveAt(heap.Count - 1);
            MakeHeapFromTop(heap, 0);
        }
        else
        {
            MakeHeapFromTop(heap, 0);
        }
        
        return minimum;
    }
}