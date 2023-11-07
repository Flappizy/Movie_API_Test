using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovie;
using Soft_Alliance.APP.Features.MovieMgt.Queries.GetMovies;

namespace Soft_Alliance.APP.Features.MovieMgt;
public static class QueryExtension
{
    public static WebApplicationBuilder AddQueries(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<GetMovieQueryHandler>();
        builder.Services.AddTransient<GetMoviesQueryHandler>();

        return builder;
    }
}
