public class Solution {
    // since there's only one path to every node, find the longest path in the tree including backwards traversal
    public int AmountOfTime(TreeNode root, int start)
    {
        Dictionary<int, TreeNode> parents = GetParents(root, start, out TreeNode infected);
        return GetLongestPath(infected, parents, []);
    }

    private int GetLongestPath (TreeNode start, Dictionary<int, TreeNode> parents, HashSet<int> visited)
    {
        int length = 0;
        Queue<TreeNode> q = new();
        q.Enqueue(start);
        while (q.Count > 0)
        {
            length++;
            for (int levelCount = q.Count; levelCount > 0; levelCount--)
            {
                TreeNode curr = q.Dequeue();
                visited.Add(curr.val);
                TreeNode parent = parents[curr.val];
                if (parent != null && !visited.Contains(parent.val))
                    q.Enqueue(parent);
                if (curr.left != null && !visited.Contains(curr.left.val))
                    q.Enqueue(curr.left);
                if (curr.right != null && !visited.Contains(curr.right.val))
                    q.Enqueue(curr.right);
            }
        }
        return length - 1;
    }

    private Dictionary<int, TreeNode> GetParents(TreeNode root, int infectedVal, out TreeNode infected)
    {
        Dictionary<int, TreeNode> parents = new()
        {
            [root.val] = null
        };
        infected = null; // needed for out keyword
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            TreeNode curr = q.Dequeue();
            if (curr.val == infectedVal)
                infected = curr;
            if (curr.left != null)
            {
                parents[curr.left.val] = curr;
                q.Enqueue(curr.left);
            }
            if (curr.right != null)
            {
                parents[curr.right.val] = curr;
                q.Enqueue(curr.right);
            }
        }
        return parents;
    }
}

public class TreeNode (int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}