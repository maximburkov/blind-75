namespace Blind_75.Array;

public class FloodFillTask : ISolution
{
    public void Solve()
    {
        var test = new []
        {
            new []{0, 0, 0},
            new []{0, 0, 0}
        };

        var res = FloodFill(test, 1, 1, 2);
    }
    
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        int rowMax = image.Length;
        int colMax = image[0].Length;
        int compareWith = image[sr][sc];

        var checks = new bool[rowMax][];
        for (int i = 0; i < rowMax; i++)
            checks[i] = new bool[colMax];

        Fill(image, sr, sc, color, compareWith, rowMax, colMax, checks);
        return image;
    }

    private void Fill(int[][] image, int row, int col, int color, int compare, int rowMax, int colMax, bool[][] checks)
    {
        if (row >= 0 && row < rowMax && col >= 0 && col < colMax && !checks[row][col] && image[row][col] == compare)
        {
            image[row][col] = color;
            checks[row][col] = true;
            Fill(image, row+1, col, color, compare, rowMax, colMax, checks);
            Fill(image, row, col+1, color, compare, rowMax, colMax, checks);
            Fill(image, row-1, col, color, compare, rowMax, colMax, checks);
            Fill(image, row, col-1, color, compare, rowMax, colMax, checks);
        }
    }
}