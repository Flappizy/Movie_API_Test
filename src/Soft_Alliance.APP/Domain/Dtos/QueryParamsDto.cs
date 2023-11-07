namespace Soft_Alliance.APP.Domain.Dtos;

public class QueryParamsDto
{
    private const int _maxPageSize = 20;
    private int _pageSize = 10;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
    }
}
