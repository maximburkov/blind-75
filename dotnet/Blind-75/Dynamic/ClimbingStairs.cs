namespace Blind_75.Dynamic;

public class ClimbingStairs : ISolution
{
    public void Solve()
    {
        var res = ClimbStairs(3);
    }
    
    public int ClimbStairs(int n)
    {
        int[] array = new int[n + 2];
        array[1] = 1; 

        for (int i = 2; i < n + 2; i++)
        {
            array[i] = array[i - 1] + array[i - 2];
        }

        return array[^1];
    }
}