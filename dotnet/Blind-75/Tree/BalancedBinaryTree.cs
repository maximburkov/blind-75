namespace Blind_75.Tree;

#nullable disable
public class BalancedBinaryTree : ISolution
{
    public void Solve()
    {
        
    }
    
    public bool IsBalanced(TreeNode root)
    {
        if (root is null)
            return true;
        
        int rh = FindHeight(root.right, 0);
        int lh = FindHeight(root.left, 0);

        return Math.Abs(lh - rh) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    public int FindHeight(TreeNode node, int height)
    {
        if (node is null)
            return height;

        height++;

        return Math.Max(FindHeight(node.left, height), FindHeight(node.right, height));
    }
}