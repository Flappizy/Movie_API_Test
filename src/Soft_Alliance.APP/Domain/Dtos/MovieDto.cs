namespace Soft_Alliance.APP.Domain.Dtos;
public class MovieDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime RealeasedDate { get; set; }
    public int Rating { get; set; }
    public decimal TicketPrice { get; set; }
    public string Country { get; set; }
    public IReadOnlyCollection<string> Genres { get; set; }
    public PhotoDto PhotoData { get; set; }
}
