/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        // var players = new Dictionary<string, int>();
        // 
        // using var reader = new TextFieldParser("basketball.csv");
        // reader.TextFieldType = FieldType.Delimited;
        // reader.SetDelimiters(",");
        // reader.ReadFields(); // ignore header row
        // while (!reader.EndOfData)
        // {
        // var fields = reader.ReadFields()!;
        // var playerId = fields[0];
        // var points = int.Parse(fields[8]);
        // }
        // 
        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
        // 
        // var topPlayers = new string[10];

        SummarizePointsOptimized();

    }

    public static void SummarizePointsOptimized()
    {
        const int playerIdIndex = 0;
        const int pointsIndex = 8;

        // Dictionary to store player ID and total points
        var playerPoints = new Dictionary<string, int>();

        // Stream the CSV file
        try
        {
            using var reader = new StreamReader("basketball.csv");
            reader.ReadLine(); // Skip header
            while (!reader.EndOfStream)
            {
                var columns = reader.ReadLine()?.Split(',');
                if (columns == null || columns.Length < 9) continue; // Skip invalid lines
                string playerId = columns[playerIdIndex].Trim('\"');
                string pointsStr = columns[pointsIndex].Trim('\"'); ;
                if (!int.TryParse(pointsStr, out int points)) continue; // Skip invalid points
                playerPoints[playerId] = playerPoints.TryGetValue(playerId, out int current) ? current + points : points;
            }

            // Sort and take top 10 players
            var topPlayers = playerPoints.OrderByDescending(p => p.Value).Take(10).ToList();

            // Display formatted output
            Console.WriteLine("Top 10 Players by Total Points:");
            Console.WriteLine("Player ID\tTotal Points");
            Console.WriteLine("----------------------------");
            foreach (var player in topPlayers)
            {
                Console.WriteLine($"{player.Key,-15}\t{player.Value}");
            }

            // Handle case with fewer than 10 players
            if (topPlayers.Count < 10)
            {
                Console.WriteLine($"\nNote: Only {topPlayers.Count} players found.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: basketball.csv not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file: {ex.Message}");
        }
    }

}