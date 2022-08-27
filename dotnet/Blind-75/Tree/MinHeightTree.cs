namespace Blind_75.Tree;

public class MinHeightTree : ISolution
{
    public void Solve()
    {
        throw new NotImplementedException();
    }
    
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if(n == 1)
            return new List<int>(new[]{0});

        int[] degrees = new int[n];
        List<List<int>> adj = new();

        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            degrees[edge[0]]++;
            degrees[edge[1]]++;
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int currentCount = n;
        Queue<int> queue = new();

        for (int i = 0; i < n; i++)
        {
            if(degrees[i] == 1)
                queue.Enqueue(i);
        }

        while (currentCount > 2)
        {
            int count = queue.Count;
            currentCount -= count;

            for (int i = 0; i < count; i++)
            {
                var popped = queue.Dequeue();
                foreach (var a in adj[popped])
                {
                    degrees[a]--;
                    if(degrees[a] == 1)
                        queue.Enqueue(a);
                }
            }
        }

        return queue.ToList();
    }
    
    
}