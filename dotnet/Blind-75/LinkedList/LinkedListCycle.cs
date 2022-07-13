namespace Blind_75.LinkedList;

#nullable disable
public class LinkedListCycle : ISolution
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public void Solve()
    {
        
    }

    public bool HasCycle(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        
        if (fast is null)
            return false;
        else
        {
            fast = fast.next;
            if (fast is null)
                return false;
        }

        while (fast != slow)
        {
            slow = slow.next;
            fast = fast.next;

            if (fast is null)
                return false;
            else
            {
                fast = fast.next;
                if (fast is null)
                    return false;
            }
        }

        return true;
    }
}