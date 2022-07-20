namespace Blind_75.Tree;

#nullable disable
public class TreeMaxDepth
{
    public int MaxDepth(TreeNode root) {
        if(root == null)
            return 0;
        
        return Math.Max(MaxDepth(root.left) + 1, MaxDepth(root.right) + 1);
    }
}