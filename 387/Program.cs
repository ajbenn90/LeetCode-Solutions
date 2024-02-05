public class Solution
{
    public int FirstUniqChar(string s)
    {
        int[] counts = new int[26];
        foreach (char c in s)
            counts[CharToIdx(c)]++;
        for (int i = 0; i < s.Length; i++)
            if (counts[CharToIdx(s[i])] == 1)
                return i;
        return -1;
    }

    private static int CharToIdx(char c)
    {
        return (int)c - (int)'a';
    }
}