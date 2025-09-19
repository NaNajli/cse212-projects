public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        // TODO Problem 2 - This should print pairs of numbers in the given array
        // Use a HashSet to store numbers we've seen
        HashSet<int> seen = new HashSet<int>();
        // Use another HashSet to avoid duplicate pairs
        HashSet<string> displayedPairs = new HashSet<string>();

        foreach (var num in numbers)
        {
            // Calculate the complement needed to sum to 10
            var complement = 10 - num;

            // If complement exists in seen, we found a pair
            if (seen.Contains(complement))
            {
                // Ensure smaller number comes first to avoid duplicates
                var smaller = Math.Min(num, complement);
                var larger = Math.Max(num, complement);
                string pair = $"{smaller},{larger}";

                // Only display if we haven't shown this pair
                if (!displayedPairs.Contains(pair))
                {
                    Console.WriteLine($"({smaller}, {larger})");
                    displayedPairs.Add(pair);
                }
            }

            // Add current number to seen
            seen.Add(num);
        }
    }
}