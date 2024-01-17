public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> counts = [];
        foreach (int x in arr)
        {
            if (!counts.ContainsKey(x))
                counts[x] = 0;
            counts[x]++;
        }
        HashSet<int> countsUsed = [];
        foreach (int x in counts.Keys)
        {
            if (countsUsed.Contains(counts[x]))
                return false;
            countsUsed.Add(counts[x]);
        }
        return true;
    }
}