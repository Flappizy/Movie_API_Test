using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Soft_Alliance.APP.Features.MovieMgt.Commands.CreateMovie;
public class CreateMovieCommand : IRequest
{
    public Response Validate()
    {
        if (Name is null || Name == "" || Name == " ")
            return new Response(false, HttpStatusCode.BadRequest, "Invalid movie name");
        if (Description is null || Description == "" || Name == " ")
            return new Response(false, HttpStatusCode.BadRequest, "Invalid description name");
        if (RealeasedDate == DateTime.MinValue)
            return new Response(false, HttpStatusCode.BadRequest, "Invalid Realeased date");
        if (Rating <= 0 || Rating > 5)
            return new Response(false, HttpStatusCode.BadRequest, "Rating can not be less than 0 or greater than 5");
        if (TicketPrice <= 0)
            return new Response(false, HttpStatusCode.BadRequest, "Ticket price must be greater than zero");
        if (Country is null || Country == "" || Country == " ")
            return new Response(false, HttpStatusCode.BadRequest, "Invalid country");
        if (Photo is null)
            return new Response(false, HttpStatusCode.BadRequest, "Invalid photo, please upload a photo");
        if (Genres.IsNullOrEmpty())
            return new Response(false, HttpStatusCode.BadRequest, "Movie must have at least one genre");

        return new Response(true, HttpStatusCode.OK, "Validation passed");
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime RealeasedDate { get; set; }
    public int Rating { get; set; }
    public decimal TicketPrice { get; set; }
    public string Country { get; set; }
    public List<string> Genres { get; set; }
    public IFormFile Photo { get; set; }
}
