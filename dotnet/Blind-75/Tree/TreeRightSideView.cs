namespace Blind_75.Tree;

#nullable disable
public class TreeRightSideView : ISolution
{
    public void Solve()
    {
        var node = new TreeNode(1, null, new TreeNode(2));
        var res = RightSideView(node);
    }
    
    public IList<int> RightSideView(TreeNode root)
    {
        IList<int> result = new List<int>();
        if (root is null) return result;
        
        Queue<(TreeNode Node, int Level)> queue = new();
        int currentLevel = 0;
        int mostRight = root.val;
        queue.Enqueue((root, 0));
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int level = current.Level;

            if (level != currentLevel)
            {
                result.Add(mostRight);
                currentLevel = level;
            }

            mostRight = current.Node.val;
            
            if(current.Node.left is not null) queue.Enqueue((current.Node.left, level + 1));
            if(current.Node.right is not null) queue.Enqueue((current.Node.right, level + 1));
        }
        
        result.Add(mostRight);
        return result;
    }
}