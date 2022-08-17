namespace Blind_75.Tree;

#nullable disable
public class ConstructBinaryTree : ISolution
{
    // TODO: Wrong Answer.
    public void Solve()
    {
        
    }
    
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        var inorderPositions = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            inorderPositions[inorder[i]] = i;
        }

        return Build(0, 0, preorder.Length, preorder, inorderPositions);
    }

    private TreeNode Build(int preStart, int inStart, int inEnd, int[] preorder, Dictionary<int, int> inMap)
    {
        if (preStart > preorder.Length - 1 || inStart > preorder.Length - 1)
            return null;

        var root = new TreeNode(preorder[inStart]);
        int inIndex = inMap[preorder[preStart]];

        root.left = Build(preStart + 1, inStart, inIndex - 1, preorder, inMap);
        root.right = Build(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inMap);
        return root;
    }
}