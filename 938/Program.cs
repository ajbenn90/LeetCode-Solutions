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
public class Solution {
    public int RangeSumBST(TreeNode root, int low, int high) {
        int sum = 0;
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            TreeNode curr = q.Dequeue();
            if (low <= curr.val && curr.val <= high)
                sum += curr.val;
            // if curr.val <= low, then left.val < high since this is a BST and values are unique
            if (curr.val > low && curr.left != null)
                q.Enqueue(curr.left);
            // if curr.val >= high, then right.val > high since this is a BST and values are unique
            if (curr.val < high && curr.right != null)
                q.Enqueue(curr.right);
        }
        return sum;
    }
}

public class TreeNode (int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}