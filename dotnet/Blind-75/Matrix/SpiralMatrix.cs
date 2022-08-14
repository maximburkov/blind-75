namespace Blind_75.Matrix;

public class SpiralMatrix : ISolution
{
    public void Solve()
    {
        int[][] matrix =
        {
            new[] {1, 2, 3},
            new[] {4, 5, 6},
            new[] {7, 8, 9}
        };
        var res = SpiralOrder(matrix);
    }
    
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        bool[,] visited = new bool[m, n];
        (int Di, int Dj)[] directions = {(0, 1), (1, 0), (0, -1), (-1, 0)};
        List<int> result = new List<int>(n * m);
        GoNextDirection(0, 0, matrix, visited, result, m, n, directions, 0);
        return result;
    }

    private bool IsInArray(int i, int j, int rowCount, int colCount) =>
        i < rowCount && j < colCount && i >= 0 && j >= 0;

    private void GoNextDirection(int i, int j, int[][] matrix, bool[,] visited, List<int> list, int m, int n, (int Di, int Dj)[] directions, int directionIndex)
    {
        if(!IsInArray(i, j, m, n) || visited[i, j]) return;
        
        while (IsInArray(i, j, m, n) && !visited[i, j])
        {
            list.Add(matrix[i][j]);
            visited[i, j] = true;
            i += directions[directionIndex].Di;
            j += directions[directionIndex].Dj;
        }

        i -= directions[directionIndex].Di;
        j -= directions[directionIndex].Dj;
        int nextDirectionIndex = (directionIndex + 1) % 4;
        i += directions[nextDirectionIndex].Di;
        j += directions[nextDirectionIndex].Dj;
        GoNextDirection(i, j, matrix, visited, list, m, n, directions, nextDirectionIndex);
    }
}