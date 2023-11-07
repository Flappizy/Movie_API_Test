using Soft_Alliance.APP.Domain.Abstractions;

namespace Soft_Alliance.APP.Domain.Models;

public class Genre : IEntity
{
    protected Genre() { }

    public static Genre Create(string name)
    {
        return new Genre
        {
            Name = name,
            Created = DateTime.UtcNow
        };
    }

    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string Name { get; set; }
    public IReadOnlyCollection<Movie> Movies { get; set; }
}
