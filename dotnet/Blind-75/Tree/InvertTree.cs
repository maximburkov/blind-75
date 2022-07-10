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

    private void SwapChildren(TreeNode node)
    {
        // Old way
        var temp = node.left;
        node.left = node.right;
        node.right = temp;
        
        // Swapping with Tuples
        (node.left, node.right) = (node.right, node.left);
    }

    private void SwapArray(int[] array, int i, int j)
    {
        // Swap Array
        (array[i], array[j]) = (array[j], array[i]);
        
        // Swap array lowered
        ref int reference = ref array[i];
        ref int reference2 = ref array[j];
        int num = array[j];
        int num2 = array[i];
        reference = num;
        reference2 = num2;
    }
}