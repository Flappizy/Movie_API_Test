using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Soft_Alliance.APP.Features.MovieMgt.Commands.CreateMovie;
using Soft_Alliance.APP.Features.MovieMgt.Commands.DeleteMovie;
using Soft_Alliance.APP.Features.MovieMgt.Commands.UpdateMovie;

namespace Soft_Alliance.APP.Features.MovieMgt;

public static class CommandExtension
{
    public static WebApplicationBuilder AddCommands(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateMovieCommandHandler>();
        builder.Services.AddTransient<DeleteMovieCommandHandler>();
        builder.Services.AddTransient<UpdateMovieCommandHandler>();

        return builder;
    }
}
