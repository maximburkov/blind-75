namespace Blind_75.LinkedList;

#nullable disable
public class MiddleLinkedList : ISolution
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
    
    public void Solve()
    {
        
    }
    
    public ListNode MiddleNode(ListNode head)
    {
        int count = 0;
        ListNode current = head;

        while (current is not null)
        {
            current = current.next;
            count++;
        }

        int mid = count / 2;

        for (int i = 0; i < mid; i++)
        {
            head = head.next;
        }

        return head;
    }
}