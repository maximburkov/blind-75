namespace Blind_75.Array;

public class ArrayContainsDuplicate : ISolution
{
    public void Solve()
    {
        
    }
    
    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int, bool> counts = new ();

        foreach (var num in nums)
        {
            if (counts.ContainsKey(num))
                return true;
            else
                counts[num] = true;
        }

        return false;
    }
}