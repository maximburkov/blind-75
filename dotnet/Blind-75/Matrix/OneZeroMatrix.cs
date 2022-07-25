namespace Blind_75.Matrix;

public class OneZeroMatrix : ISolution
{
    public void Solve()
    {
        throw new NotImplementedException();
    }
    
    public int[][] UpdateMatrix(int[][] mat)
    {
        return mat;
    }

    private int PathLength(int[][] mat, int row, int col, bool[][] visited) // Visited should be renewed for each cell
    {
        return 1;
    }
}