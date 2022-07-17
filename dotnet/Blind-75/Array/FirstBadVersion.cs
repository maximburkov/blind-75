namespace Blind_75.Array;

public class FirstBadVersionTask : ISolution
{
    // External API call.
    private bool IsBadVersion(int m) => true;
    
    public int FirstBadVersion(int n) {
        int l = 1;
        int r = n;
        int res = -1;
        
        while (l <= r)
        {
            int m = l + (r - l)/2;
            
            if(IsBadVersion(m))
            {
                res = m;
                r = m - 1;
            }
            else{
                l = m+1;
            }
            
        }
        
        return res;
    }
    
    public void Solve()
    {
        
    }
}