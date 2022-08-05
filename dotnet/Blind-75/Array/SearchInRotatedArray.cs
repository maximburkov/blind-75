namespace Blind_75.Array;

public class SearchInRotatedArray : ISolution
{
    public void Solve()
    {
        
    }
    
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;
        while (l < r)
        {
            int m = (l + r) / 2;

            if (nums[m] > nums[r])
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        int pivot = l;

        if (pivot == 0)
        {
            l = 0;
            r = nums.Length - 1;
        }
        else if (nums[0] > target)
        {
            l = pivot;
            r = nums.Length - 1;
        }
        else
        {
            l = 0;
            r = pivot;
        }

        while (l <= r)
        {
            int m = (l + r) / 2;

            if (nums[m] == target)
                return m;

            if (nums[m] < target)
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return -1;
    }
}