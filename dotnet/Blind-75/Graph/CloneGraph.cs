namespace Blind_75.Graph;

#nullable disable
public class CloneGraph : ISolution
{
    public class Node {
        public int val;
        public IList<Node> neighbors;

        public Node() {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
    }
    
    public void Solve()
    {
        
    }
    
    public Node CloneGraphSolve(Node node)
    {
        Queue<Node> q = new Queue<Node>();
        Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
                
        if (node == null)
        {
            return null;
        }

        q.Enqueue(node);
        dict.Add(node, new Node(node.val));

        while (q.Count > 0)
        {
            Node cur = q.Dequeue();

            foreach (var nei in cur.neighbors)
            {
                if (!dict.ContainsKey(nei))
                {
                    dict.Add(nei, new Node(nei.val));
                    q.Enqueue(nei);
                }

                dict[cur].neighbors.Add(dict[nei]);
            }
        }

        return dict[node];
    }
}