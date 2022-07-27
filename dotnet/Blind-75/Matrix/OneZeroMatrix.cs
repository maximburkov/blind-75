namespace Blind_75.Matrix;

public class OneZeroMatrix : ISolution
{
    // TODO: fix errors
    public void Solve() // [[0,1,0,1,1],[1,1,0,0,1],[0,0,0,1,0],[1,0,1,1,1],[1,0,0,0,1]]
    {
        int[][] mat = new[]
        {
            new int[] {0,1,0,1,1},
            new int[] {1,1,0,0,1},
            new int[] {0,0,0,1,0},
            new int[] {1,0,1,1,1},
            new int[] {1,0,0,0,1}
        };
        var res = UpdateMatrix(mat);
    }
    
    public int[][] UpdateMatrix(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                    mat[i][j] = 0;
                else
                {
                    int top = PathLength(mat, i - 1, j, NewVisited(m, n), 1);
                    int bottom = PathLength(mat, i + 1, j, NewVisited(m, n), 1);
                    int left = PathLength(mat, i, j - 1, NewVisited(m, n), 1);
                    int right = PathLength(mat, i, j + 1, NewVisited(m, n), 1);
                    
                    mat[i][j] = Math.Min(top, Math.Min(bottom, Math.Min(left, right)));
                }
            }
        }
        
        return mat;
    }

    private bool[][] NewVisited(int m, int n)
    {
        bool[][] visited = new bool[m][];

        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }

        return visited;
    }

    private int PathLength(int[][] mat, int row, int col, bool[][] visited, int path) // Visited should be renewed for each cell
    {
        if (row >= mat.Length || row < 0 || col >= mat[0].Length || col < 0)
            return int.MaxValue;

        if (visited[row][col])
            return int.MaxValue;

        visited[row][col] = true;

        if (mat[row][col] == 0)
            return path;

        int top = PathLength(mat, row - 1, col, visited, path + 1);
        int bottom = PathLength(mat, row + 1, col, visited, path + 1);
        int left = PathLength(mat, row, col - 1, visited, path + 1);
        int right = PathLength(mat, row, col + 1, visited, path + 1);

        return Math.Min(top, Math.Min(bottom, Math.Min(left, right)));
    }
}