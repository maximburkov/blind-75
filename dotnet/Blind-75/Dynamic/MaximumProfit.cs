namespace Blind_75.Dynamic;

public class MaximumProfit : ISolution
{
    public void Solve()
    {
        var lines = File.ReadLines("D:\\test.txt").ToArray();
        var start = lines[0].Split(',').Select(int.Parse).ToArray();
        var end = lines[1].Split(',').Select(int.Parse).ToArray();
        var profit = lines[2].Split(',').Select(int.Parse).ToArray();

        
        var res = JobScheduling(start, end, profit);
    }

    struct Job
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Profit { get; set; }
    }

    private readonly int[] _calculatedProfits = Enumerable.Repeat(-1, 50001).ToArray();

    private int FindNextIndex(List<Job> jobs, int start, int endTime)
    {
        int l = start;
        int r = jobs.Count - 1;

        int nextIndex = jobs.Count;

        while (l <= r)
        {
            int m = (l + r) / 2;

            if (jobs[m].Start >= endTime)
            {
                nextIndex = m;
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        return nextIndex;
    }

    private int FindMaxProfit(List<Job> jobs, int index) // Check if current profit no more than int.Max
    {
        if (index >= jobs.Count) 
            return 0;

        if (_calculatedProfits[index] != -1)
            return _calculatedProfits[index];

        int nextIndex = FindNextIndex(jobs, index + 1, jobs[index].End);
        int maxProfit = Math.Max(jobs[index].Profit + FindMaxProfit(jobs, nextIndex), FindMaxProfit(jobs, index + 1));
        _calculatedProfits[index] = maxProfit;
        return maxProfit;
    }
    
    
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var jobs = startTime.Zip(endTime, profit).Select(i => new Job
        {
            Start = i.First,
            End = i.Second,
            Profit = i.Third
        }).OrderBy(i => i.Start).ToList();

        return FindMaxProfit(jobs, 0);
    }
}