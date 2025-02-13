using Selu383.SP25.Api;

using Selu383.SP25.Api.Entities;

public class TheaterSeeder
{
    public static async Task Initialize(DataContext context)
    {
        if (!context.Theaters.Any())
        {
            await SeedTheaters(context);
        }
    }

    private static async Task SeedTheaters(DataContext context)
    {
        var seededTheaters = new List<Theater>()
        {
            new Theater
            {
                Name = "QFX Cinemas",
                SeatCount = 250,
                Address = "Civil Mall, Kathmandu"
            },
            new Theater
            {
                Name = "Big Cinemas",
                SeatCount = 340,
                Address = "345 Durbarmarg, Ktm"
            },
            new Theater
            {
                Name = "ACM Theaters",
                SeatCount = 260,
                Address = "230 Pecan Street, Hammond"
            }
        };

        context.Theaters.AddRange(seededTheaters);
        await context.SaveChangesAsync();
    }
}