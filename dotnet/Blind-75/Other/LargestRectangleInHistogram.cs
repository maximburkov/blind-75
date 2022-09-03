namespace Blind_75.Other;

public class LargestRectangleInHistogram : ISolution
{
    public void Solve()
    {
        var res = LargestRectangleArea(new[] {2, 1, 5, 6, 2, 3});
    }
    
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        Stack<(int Index, int Height)> stack = new Stack<(int Index, int Height)>();
        stack.Push((0, heights[0]));
        int maxArea = heights[0];

        for (int i = 1; i < n; i++)
        {
            int index = i;
            
            while (stack.Any() && stack.Peek().Height > heights[i])
            {
                var popped = stack.Pop();
                index = popped.Index;
                maxArea = Math.Max((i - popped.Index) * popped.Height, maxArea);
            }

            stack.Push((index, heights[i]));
        }

        while (stack.Any())
        {
            var popped = stack.Pop();
            maxArea = Math.Max(maxArea, (n - popped.Index) * popped.Height);
        }

        return maxArea;
    }
}