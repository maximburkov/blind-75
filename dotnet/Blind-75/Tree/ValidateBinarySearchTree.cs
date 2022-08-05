using Blind_75.Graph;

namespace Blind_75.Tree;

#nullable disable
public class ValidateBinarySearchTree : ISolution
{
    public void Solve()
    {
        throw new NotImplementedException();
    }
    
    public bool IsValidBST(TreeNode root)
    {
        return Dfs(root, long.MinValue, long.MaxValue);
    }
    
    private bool Dfs(TreeNode root, long min, long max) {
        if (root == null) return true;
        if (min < root.val && root.val < max) {
            var leftResult = Dfs(root.left, min, root.val);
            var rightResult = Dfs(root.right, root.val, max);

            if (leftResult && rightResult) {
                return true;
            }
        }

        return false;
    }

}