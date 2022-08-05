namespace Blind_75.Graph;

// TODO: Not working properly
public class RottingOranges : ISolution
{
    public void Solve()
    {
        
    }
    
    public int OrangesRotting(int[][] grid)
    {
        int fresh = 1, rotting = 2, empty = 0;
        
        // Count fresh
        int numberOfFresh = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == fresh)
                {
                    numberOfFresh++;
                }
            }
        }

        if (numberOfFresh == 0)
            return 0;
        
        // Add rotting to queue
        HashSet<(int i, int j)> currentRotting = new();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == rotting)
                {
                    currentRotting.Add((i, j));
                }
            }
        }

        int minutes = 0;

        while (numberOfFresh > 0 && currentRotting.Count > 0)
        {
            // Dequeue all current level items
            var list = currentRotting.ToList();
            currentRotting.Clear();
            
            // Enqueue adjacent items
            foreach (var adj in list)
            {
                int i = adj.i, j = adj.j;
                if (grid[i][j] == fresh)
                {
                    grid[i][j] = rotting;
                    numberOfFresh--;
                    currentRotting.Add((i, j));
                }
                else if (grid[i][j] == rotting)
                {
                    if (i + 1 < grid.Length && grid[i + 1][j] == fresh)
                    {
                        currentRotting.Add((i+1, j));
                    }
                    
                    if (i - 1 >= 0 && grid[i - 1][j] == fresh)
                    {
                        currentRotting.Add((i-1, j));
                    }
                    
                    if (j + 1 < grid[0].Length && grid[i][j+1] == fresh)
                    {
                        currentRotting.Add((i, j+1));
                    }
                    
                    if (j - 1 >= 0 && grid[i][j-1] == fresh)
                    {
                        currentRotting.Add((i, j-1));
                    }
                }
            }
            
            minutes++;
        }

        return numberOfFresh == 0 ? minutes : -1;
    }
}