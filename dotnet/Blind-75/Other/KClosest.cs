namespace Blind_75.Other;

public class KClosestSolution : ISolution
{
    public void Solve()
    {
        
    }
    
    public int[][] KClosest(int[][] points, int k)
    {
        List<(int Index, int Dist)> dists = new List<(int, int)>();

        for (int i = 0; i < points.Length; i++)
        {
            dists.Add((i, points[i][0]*points[i][0] + points[i][1] * points[i][1]));
        }

        var top = dists.OrderBy(i => i.Dist).Take(k).Select(i => i.Index).ToArray();

        int[][] res = new int[k][];

        for (int i = 0; i < k; i++)
        {
            res[i] = points[top[i]];
        }

        return res;
    }
}