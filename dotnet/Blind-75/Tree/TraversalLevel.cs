namespace Blind_75.Tree;

#nullable disable
public class TraversalLevel : ISolution
{
    public void Solve()
    {
        
    }
    
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> list = new List<IList<int>>();
        Queue<(TreeNode Node, int Level)> queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 0));

        while (queue.TryDequeue(out var node) && node.Node is not null)
        {
            int level = node.Level;
            TreeNode treeNode = node.Node;
            
            if(list.Count <= level)
                list.Add(new List<int>());

            list[level].Add(treeNode.val);
            
            if(treeNode.left is not null)
                queue.Enqueue((treeNode.left, level + 1));
            
            if(treeNode.right is not null)
                queue.Enqueue((treeNode.right, level + 1));
        }

        return list;
    }
}