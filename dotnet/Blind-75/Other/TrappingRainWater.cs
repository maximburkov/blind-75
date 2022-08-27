namespace Blind_75.Other;

public class TrappingRainWater : ISolution
{
    public void Solve()
    {
        var test = Trap(new[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1});
    }
    
    public int Trap(int[] height)
    {
        int l = 0, r = height.Length - 1;
        int sum = 0, dif = 0;
        int maxLeft = 0, maxRight = 0;

        while (l < r)
        {
            if (maxLeft <= maxRight)
            {
                maxLeft = Math.Max(maxLeft, height[l]);
                dif = maxLeft - height[l];
                if (dif > 0)
                    sum += dif;

                l++;
            }
            else
            {
                maxRight = Math.Max(maxRight, height[r]);
                dif = maxRight - height[r];
                if (dif > 0)
                    sum += dif;

                r--;
            }
        }

        return sum;
    }
}