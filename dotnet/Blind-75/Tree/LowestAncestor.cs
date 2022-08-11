using Blind_75.Graph;

namespace Blind_75.Tree;

#nullable disable
public class LowestAncestor : ISolution
{
    public void Solve()
    {
        
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        if (root is null)
            return null;

        if (root == q || root == p)
        {
            return root;
        }

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null)
        {
            return root;
        }

        return left ?? right;
    }
}