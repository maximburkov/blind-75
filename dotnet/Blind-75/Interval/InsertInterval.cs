namespace Blind_75.Interval;

public class InsertInterval : ISolution
{
    public void Solve()
    {
        var array = new[] // [[1,2],[3,5],[6,7],[8,10],[12,16]]
        {
            new[] {3, 5},
            new[] {12, 15}
        };

        var res = Insert(array, new[] {6, 6});
    }
    
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int first = newInterval[0];
        int second = newInterval[1];
        List<int[]> result = new List<int[]>();

        if (intervals.Length == 0 || (first <= intervals[0][0] && second >= intervals[^1][1]))
            return new[] {newInterval};
        
        if (second < intervals[0][0])
        {
            result.Add(newInterval);
            result.AddRange(intervals);
            return result.ToArray();
        }

        if (first > intervals[^1][1])
        {
            result.AddRange(intervals);
            result.Add(newInterval);
            return result.ToArray();
        }

        int i = 0;

        // TODO: Not Working here
        while (!IsOverlapping(newInterval, intervals[i]))
        {
            result.Add(intervals[i]);
            i++;
        }

        int mergeStart = Math.Min(newInterval[0], intervals[i][0]);

        while (i < intervals.Length && IsOverlapping(newInterval, intervals[i]))
        {
            i++;
        }

        int mergeEnd = Math.Max(newInterval[1], intervals[i-1][1]);
        result.Add(new[]{mergeStart, mergeEnd});

        while (i < intervals.Length)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }

    private bool IsOverlapping(int[] first, int[] second) =>
        Math.Min(first[1], second[1]) >= Math.Max(first[0], second[0]);
}

// TODO: Compare with working solution.
public class WorkingSolution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var n = intervals.Length;

        if (n == 0) {
            return new int[][] { newInterval };
        }

        var result = new List<int[]>();

        // 1. insert
        var isAdded = false;
        for (int i = 0; i < n; i++) {
            if (intervals[i][0] > newInterval[0]) {
                // first item larger than newInterval
                isAdded = true;
                result.Add(newInterval);
            }
            result.Add(intervals[i]);
        }

        // 1.1 tail?
        if (!isAdded) {
            result.Add(newInterval);
        }

        // 2. merge
        result = mergeIntervals(result);
        return result.ToArray();
    }

    private List<int[]> mergeIntervals(List<int[]> intervals) {
        var n = intervals.Count;
        if (n <= 1) return intervals;

        var result = new List<int[]>();
        result.Add(intervals[0]);

        for (int i = 1; i < n; i++) {
            var cur = intervals[i];
            var lastFromResult = result.Last();

            if (lastFromResult[1] >= cur[0]) {
                lastFromResult[1] = Math.Max(lastFromResult[1], cur[1]);
            } else {
                result.Add(cur);
            }
        }

        return result;
    }
}