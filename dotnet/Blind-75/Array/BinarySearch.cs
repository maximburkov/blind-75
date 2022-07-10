namespace Blind_75.Array;

public class BinarySearch : ISolution
{
    public void Solve()
    {
        var res = Search(new[] {-1, 0, 3, 5, 9, 12}, 13);
    }
    
    public int Search(int[] nums, int target) {
        int l = 0;
        int r = nums.Length;
        
        while (l <= r) 
        {
            int m = (l + r)/2;

            if (m < 0 || m > nums.Length)
                return -1;
            
            if (nums[m] == target)
            {
                return m;
            }

            if (nums[m] > target) 
            {
                r = m - 1;
            }
            else
            {
                l = m +1;
            }
        }
        
        return -1;
    }
}