using System.Data.Common;

namespace Blind_75.Matrix;
#nullable disable

// Copied from Answers.
public class WordSearch : ISolution
{
    private int[] dx = { 0, 0, 1, -1 },
        dy = { 1, -1, 0, 0 };
    
    public bool Exist(char[][] board, string word) {
        if (board == null || board.Length == 0 || word == null || word == string.Empty)
            return false;
        
        for (int i = 0; i < board.Length; i++)
        for (int j = 0; j < board[0].Length; j++)
            if (board[i][j] == word[0] && DFS(board, i, j, word, 0, new bool[board.Length, board[0].Length]))
                return true;                                                           
        
        return false;
    }
    
    private bool DFS(char[][] board, int i, int j, string word, int k, bool[,] visited)
    {        
        if (board[i][j] == word[k])
        {
            if (k == word.Length - 1)
                return true;
            
            visited[i, j] = true;
        
            for (int l = 0; l < 4; l++)
            {
                int newX = i + dx[l],
                    newY = j + dy[l];

                if (newX > -1 && newX < board.Length && newY > -1 && newY < board[0].Length && !visited[newX, newY] && DFS(board, newX, newY, word, k + 1, visited))
                    return true;
            }
            
            visited[i, j] = false;
        }
        
        return false;
    }

    public void Solve()
    {
        throw new NotImplementedException();
    }
}