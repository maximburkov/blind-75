namespace Blind_75.Tree;

#nullable disable
public class DiameterTree : ISolution
{
    public void Solve()
    {
        TreeNode root = new(1, new(2, new(4), new(5)), new(3));
        var res = DiameterOfBinaryTree(root);
    }
    
    public int DiameterOfBinaryTree(TreeNode root)
    {
        FindHeight(root);
        return max;
    }

    private int max = 0;

    private int FindHeight(TreeNode node)
    {
        if (node == null)
            return -1;
        int lh = FindHeight(node.left) + 1;
        int rh = FindHeight(node.right) + 1;

        max = Math.Max(max, lh + rh);
        return Math.Max(lh, rh);
    }
}