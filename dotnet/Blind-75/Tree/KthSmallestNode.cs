namespace Blind_75.Tree;

#nullable disable
public class KthSmallestNode : ISolution
{
    public void Solve()
    {
        throw new NotImplementedException();
    }
    
    public int KthSmallest(TreeNode root, int k)
    {
        int counter = 0;
        var result = Traverse(root, ref counter, k);
        return result ?? -1;
    }
    
    private int? Traverse(TreeNode node, ref int counter, int k)
    {
        int? leftResult = null, rightResult = null;

        if (node.left is not null)
            leftResult = Traverse(node.left, ref counter, k);
        
        if (++counter == k) return node.val;

        if (node.right is not null && leftResult is null)
            rightResult = Traverse(node.right, ref counter, k);

        return leftResult ?? rightResult;
    }
}