// FAILING SOME TESTS

public class Solution {
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
    {
        // check if there are invalid edges
        bool[] visited = new bool[n];
        Queue<int> queue = new();
        queue.Enqueue(0);
        while (queue.TryDequeue(out int currNode))
        {
            if (visited[currNode])
                return false;
            visited[currNode] = true;
            if (leftChild[currNode] != -1)
                queue.Enqueue(leftChild[currNode]);
            if (rightChild[currNode] != -1)
                queue.Enqueue(rightChild[currNode]);
        }
        // check if there are nodes not connected to anything
        for (int i = 0; i < n; i++)
        {
            if (leftChild[i] != -1 && !visited[leftChild[i]])
                return false;
            if (rightChild[i] != -1 && !visited[rightChild[i]])
                return false;
        }
        return true;
    }

    // public static void Main()
    // {
    //     int n = 6;
    //     int[] leftChild = {1, -1, -1, 4, -1, -1};
    //     int[] rightChild = {2, -1, -1, 5, -1, -1};
    //     Console.WriteLine(new Solution().ValidateBinaryTreeNodes(n, leftChild, rightChild));
    // }
}