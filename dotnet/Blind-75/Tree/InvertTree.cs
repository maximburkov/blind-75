namespace Blind_75.Tree;

#nullable disable
public class InvertBinaryTree : ISolution
{
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public void Solve()
    {
        int[] arr = new[] {1, 2, 3, 4, 5};
        ref int a = ref arr[2];
        a = 10;
        


        var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        var res = InvertTree(root);
    }
    
    public TreeNode InvertTree(TreeNode root) 
    {
        InvertNodes(root);
        return root;
    }

    private void InvertNodes(TreeNode node)
    {
        if (node is null)
            return;
        
        (node.left, node.right) = (node.right, node.left);
        InvertNodes(node.left);
        InvertNodes(node.right);
    }
}