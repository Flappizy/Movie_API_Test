using Microsoft.AspNetCore.Builder;

namespace Soft_Alliance.APP.Features.MovieMgt;
public static class MovieMgtModule
{
    public static WebApplicationBuilder AddMovieMgtModule(this WebApplicationBuilder builder)
    {
        builder.AddCommands();
        builder.AddQueries();
        return builder;
    }
}
