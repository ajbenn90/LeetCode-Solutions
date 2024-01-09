/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        return GetLeafSequence(root1).SequenceEqual(GetLeafSequence(root2));
    }

    private List<int> GetLeafSequence(TreeNode root)
    {
        List<int> leafSeq = [];
        Stack<TreeNode> stack = new();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode curr = stack.Pop();
            if (curr.left == null && curr.right == null)
                leafSeq.Add(curr.val);
            else
            {
                if (curr.right != null)
                    stack.Push(curr.right);
                if (curr.left != null)
                    stack.Push(curr.left);
            }
        }
        return leafSeq;
    }
}

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}