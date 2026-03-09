using backend.Models;

namespace backend.Data;

public static class SeedData
{
    public static async Task Initialize(BowlingLeagueContext context)
    {
        if (context.Teams.Any())
            return;

        // Create teams - Marlins and Sharks (from assignment)
        var marlins = new Team { TeamID = 1, TeamName = "Marlins" };
        var sharks = new Team { TeamID = 2, TeamName = "Sharks" };

        context.Teams.AddRange(marlins, sharks);

        // Sample bowlers for Marlins and Sharks (from typical Bowling League DB)
        var bowlers = new List<Bowler>
        {
            // Marlins
            new Bowler { BowlerID = 1, BowlerFirstName = "Barbara", BowlerMiddleInit = "A", BowlerLastName = "Fournier", BowlerAddress = "67 Willow Dr.", BowlerCity = "Bellevue", BowlerState = "WA", BowlerZip = "98004", BowlerPhoneNumber = "206-555-0101", TeamID = 1 },
            new Bowler { BowlerID = 2, BowlerFirstName = "David", BowlerMiddleInit = "A", BowlerLastName = "Fournier", BowlerAddress = "67 Willow Dr.", BowlerCity = "Bellevue", BowlerState = "WA", BowlerZip = "98004", BowlerPhoneNumber = "206-555-0102", TeamID = 1 },
            new Bowler { BowlerID = 3, BowlerFirstName = "John", BowlerMiddleInit = "B", BowlerLastName = "Patterson", BowlerAddress = "574 Puzzle Ln.", BowlerCity = "Kirkland", BowlerState = "WA", BowlerZip = "98033", BowlerPhoneNumber = "425-555-0103", TeamID = 1 },
            new Bowler { BowlerID = 4, BowlerFirstName = "Carol", BowlerMiddleInit = "C", BowlerLastName = "Viescas", BowlerAddress = "1637 Revelations Blvd.", BowlerCity = "Bellevue", BowlerState = "WA", BowlerZip = "98004", BowlerPhoneNumber = "206-555-0104", TeamID = 1 },
            new Bowler { BowlerID = 5, BowlerFirstName = "Alaina", BowlerMiddleInit = null, BowlerLastName = "Hallmark", BowlerAddress = "4221 First Ave.", BowlerCity = "Seattle", BowlerState = "WA", BowlerZip = "98115", BowlerPhoneNumber = "206-555-0105", TeamID = 1 },
            // Sharks
            new Bowler { BowlerID = 6, BowlerFirstName = "Stephanie", BowlerMiddleInit = "D", BowlerLastName = "Brown", BowlerAddress = "900 Apple Way", BowlerCity = "Bellevue", BowlerState = "WA", BowlerZip = "98004", BowlerPhoneNumber = "206-555-0106", TeamID = 2 },
            new Bowler { BowlerID = 7, BowlerFirstName = "Michael", BowlerMiddleInit = "E", BowlerLastName = "Hernandez", BowlerAddress = "123 Oak St.", BowlerCity = "Kirkland", BowlerState = "WA", BowlerZip = "98033", BowlerPhoneNumber = "425-555-0107", TeamID = 2 },
            new Bowler { BowlerID = 8, BowlerFirstName = "Rachel", BowlerMiddleInit = "F", BowlerLastName = "Thompson", BowlerAddress = "456 Pine Ave.", BowlerCity = "Seattle", BowlerState = "WA", BowlerZip = "98101", BowlerPhoneNumber = "206-555-0108", TeamID = 2 },
            new Bowler { BowlerID = 9, BowlerFirstName = "Kevin", BowlerMiddleInit = "G", BowlerLastName = "Cheng", BowlerAddress = "789 Maple Dr.", BowlerCity = "Bellevue", BowlerState = "WA", BowlerZip = "98006", BowlerPhoneNumber = "425-555-0109", TeamID = 2 },
            new Bowler { BowlerID = 10, BowlerFirstName = "Jennifer", BowlerMiddleInit = "H", BowlerLastName = "Johnson", BowlerAddress = "321 Cedar Ln.", BowlerCity = "Redmond", BowlerState = "WA", BowlerZip = "98052", BowlerPhoneNumber = "425-555-0110", TeamID = 2 },
        };

        context.Bowlers.AddRange(bowlers);
        await context.SaveChangesAsync();
    }
}
