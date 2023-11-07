using Microsoft.AspNetCore.Http;
using Soft_Alliance.APP.Features.MovieMgt.Commands.CreateMovie;

namespace Soft_Alliance.APP_UnitTests.CommandsTests.CreateMovieTests;
public class CreateMovieTestsCommandHandlerTest
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { "gemini man", null, DateTime.MinValue, 0, 0, null, null, null };
        yield return new object[] { "gemini man", "action movie", DateTime.MinValue, 0, 0, null, null, null };
        yield return new object[] { "gemini man", "action movie", DateTime.UtcNow, 1, 0, null, null, null };
        yield return new object[] { "gemini man", "action movie", DateTime.UtcNow, 1, 5000, null, null, null };
        yield return new object[] { "gemini man", "action movie", DateTime.UtcNow, 1, 5000, "Nigeria", null, null };
        yield return new object[] { "gemini man", "action movie", DateTime.UtcNow, 5, 5000, "Nigeria", new List<string> { "action", "adventure" }, null };
    }

    public static IEnumerable<object[]> ValidTestData()
    {
        yield return new object[] { "gemini man", "action movie", DateTime.UtcNow, 5, 5000, "Nigeria", new List<string> { "action", "adventure" }, new If };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Should_Return_NotSucceeded_If_Validation_Fails(string name, string description, DateTime releasedDate,
    int rating, decimal ticketPrice, string country, List<string> genres, IFormFile photo)
    {
        var command = new CreateMovieCommand
        {
            Name = name,
            Description = description,
            Rating = rating,
            TicketPrice = ticketPrice,
            Country = country,
            Genres = genres,
            Photo = photo,
            RealeasedDate = releasedDate
        };

        var validatedResult = command.Validate();

        Assert.False(validatedResult.NotSucceeded);
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void Should_Return_Succeeded_If_Validation_Passes(string name, string description, DateTime releasedDate,
    int rating, decimal ticketPrice, string country, List<string> genres, IFormFile photo)
    {
        var command = new CreateMovieCommand
        {
            Name = name,
            Description = description,
            Rating = rating,
            TicketPrice = ticketPrice,
            Country = country,
            Genres = genres,
            Photo = photo,
            RealeasedDate = releasedDate
        };

        var validatedResult = command.Validate();

        Assert.False(validatedResult.Succeeded);
    }

}
