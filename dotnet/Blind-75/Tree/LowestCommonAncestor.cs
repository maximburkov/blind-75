namespace Blind_75.Tree;

#nullable disable
public class LowestCommonAncestorTask : ISolution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
            return null;

        int val = root.val;
        if (p.val > val && q.val > val)
            return LowestCommonAncestor(root.right, p, q);

        if (p.val < val && q.val < val)
            return LowestCommonAncestor(root.left, p, q);

        return root;
    }

    public void Solve()
    {
        var res = LowestCommonAncestor(null, null, null);
    }
}