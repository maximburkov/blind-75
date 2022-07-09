namespace Blind_75.LinkedList;

// https://leetcode.com/problems/merge-two-sorted-lists/
#nullable disable
public class MergeTwoSortedLists : ISolution
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

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode head = new ListNode();
        ListNode result = head;
        
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                result.next = list1;
                list1 = list1.next;
            }
            else
            {
                result.next = list2;
                list2 = list2.next;
            }
            
            result = result.next;
        }

        if (list1 is not null)
            result.next = list1;

        if (list2 is not null)
            result.next = list2;

        return head.next;
    }

    public void Solve()
    {
        ListNode list1 = new ListNode(1);
        list1.next = new(2);
        list1.next.next = new(4);

        var list2 = new ListNode(1);
        list2.next = new(3);
        list2.next.next = new(4);

        var res = MergeTwoLists(list1, list2);
    }
}