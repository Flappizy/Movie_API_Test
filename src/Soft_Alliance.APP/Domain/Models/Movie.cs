using Soft_Alliance.APP.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soft_Alliance.APP.Domain.Models;

public class Movie : IEntity
{
    protected Movie() { }

    public static Movie New(int id)
    {
        return new Movie { Id = id };
    }

    public static Movie Create(string name, string description, DateTime realeasedDate, int rating, decimal ticketPrice, 
        string country, List<Genre> genres, byte[] photoData, string photoFormat)
    {
        return new Movie
        {
            Created = DateTime.UtcNow,
            Name = name,
            Description = description,
            RealeasedDate = realeasedDate,
            Rating = rating,
            TicketPrice = ticketPrice,
            Country = country,
            Genres = genres,
            PhotoData = photoData,
            PhotoFormat = photoFormat
        };
    }

    public void UpdateMovie(string name, string description, DateTime realeasedDate, int rating, decimal ticketPrice,
        string country, List<Genre> genres, byte[] photoData, string photoFormat)
    {
        Name = Name != name ? name : Name;
        Description = Description != description ? description : Description;
        RealeasedDate = RealeasedDate != realeasedDate ? realeasedDate : RealeasedDate;
        Rating = Rating != rating ? rating : Rating;
        TicketPrice = TicketPrice != ticketPrice ? ticketPrice : TicketPrice;
        Country = Country != country ? country : Country;
        Genres = genres;
        PhotoData = PhotoData != photoData ? photoData : photoData;
        PhotoFormat = PhotoFormat != photoFormat ? photoFormat : PhotoFormat;
    }

    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime RealeasedDate { get; set; }
    public int Rating { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TicketPrice { get; set; }
    public string Country { get; set; }
    public IReadOnlyCollection<Genre> Genres { get; set; }
    public byte[] PhotoData { get; set; }
    public string PhotoFormat { get; set; }
}
