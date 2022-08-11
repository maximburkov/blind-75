using System.Collections.Immutable;

namespace Blind_75.Interval;

public class MergeIntervals : ISolution
{
    public void Solve()
    {
        var test = Merge(new[] {new[] {1, 4}, new[] {2, 3}});
    }
    
    public int[][] Merge(int[][] intervals)
    {
        intervals = intervals.OrderBy(i => i[0]).ToArray();
        var result = new List<int[]>();
        int start = intervals[0][0];
        int end = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] > end)
            {
                result.Add(new[]{start, end});
                start = intervals[i][0];
            }
            
            if(intervals[i][1] > end)
                end = intervals[i][1];
        }
        
        result.Add(new[]{start, end});
        return result.ToArray();
    }
}