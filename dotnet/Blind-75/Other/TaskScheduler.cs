namespace Blind_75.Other;

public class TaskScheduler : ISolution
{
    public void Solve()
    {
        var res = LeastInterval(new[] {'A', 'A', 'A', 'B', 'B', 'B'}, 2);
    }
    
    public int LeastInterval(char[] tasks, int n)
    {
        if (n == 0) return tasks.Length;

        Dictionary<char, int> counts = new();

        foreach (var task in tasks)
        {
            if (counts.ContainsKey(task))
                counts[task]++;
            else
                counts[task] = 1;
        }

        char mostRepeatingChar = ' ';
        int maxCount = 0;
        foreach (var pair in counts)
        {
            if (pair.Value > maxCount)
            {
                mostRepeatingChar = pair.Key;
                maxCount = pair.Value;
            }
        }

        maxCount--;

        int idleCount = maxCount * n;

        foreach (var pair in counts)
        {
            if (pair.Key != mostRepeatingChar)
            {
                idleCount -= Math.Min(pair.Value, maxCount);
            }
        }

        return idleCount > 0 ? tasks.Length + idleCount : tasks.Length;
    }
}