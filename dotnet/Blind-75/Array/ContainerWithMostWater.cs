namespace Blind_75.Array;

public class ContainerWithMostWater : ISolution
{
    public void Solve()
    {
        
    }
    
    public int MaxArea(int[] height)
    {
        int l = 0, r = height.Length - 1;
        int maxArea = 0;

        while (l < r)
        {
            var length = r - l;
            if (height[l] < height[r])
            {
                maxArea = Math.Max(maxArea, length * height[l]);
                l++;
            }
            else
            {
                maxArea = Math.Max(maxArea, length * height[r]);
                r--;
            }
        }

        return maxArea;
    }
}