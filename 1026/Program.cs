public class Solution {
    public int MaxAncestorDiff(TreeNode root) 
    {
        // get the max and min value of every subtree excluding the subtree's root
        // the max ancestor diff is the max diff between a subtree's root and its min or max found above
        Dictionary<TreeNode, int> mins = [];
        Dictionary<TreeNode, int> maxes = [];
        SubtreeMinMax(root, mins, maxes);

        int maxDiff = 0;
        Stack<TreeNode> stack = [];
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode curr = stack.Pop();
            int currMaxDiff = Math.Max(Math.Abs(curr.val - mins[curr]), Math.Abs(curr.val - maxes[curr]));
            maxDiff = Math.Max(maxDiff, currMaxDiff);
            if (curr.left != null)
                stack.Push(curr.left);
            if (curr.right != null)
                stack.Push(curr.right);
        }
        return maxDiff;
    }

    // finds the minimum and maximum value in root's subtree, not including root itself
    private void SubtreeMinMax(TreeNode root, Dictionary<TreeNode, int> mins, Dictionary<TreeNode, int> maxes)
    {
        if (root.left == null && root.right == null)
        {
            mins[root] = maxes[root] = root.val;
            return;
        }
        int leftMin, rightMin, leftMax, rightMax;
        leftMin = rightMin = int.MaxValue;
        leftMax = rightMax = int.MinValue;
        if (root.left != null)
        {
            SubtreeMinMax(root.left, mins, maxes);
            leftMin = Math.Min(root.left.val, mins[root.left]);
            leftMax = Math.Max(root.left.val, maxes[root.left]);
        }
        if (root.right != null)
        {
            SubtreeMinMax(root.right, mins, maxes);
            rightMin = Math.Min(root.right.val, mins[root.right]);
            rightMax = Math.Max(root.right.val, maxes[root.right]);
        }
        mins[root] = Math.Min(leftMin, rightMin);
        maxes[root] = Math.Max(leftMax, rightMax);
    }
}

public class TreeNode (int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}