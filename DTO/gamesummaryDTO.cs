namespace WebApplication1.DTO;

public record class gamesummaryDTO(
    int Id,
    string Name,
    string Genre,
    Decimal Price,
    DateOnly ReleaseDate
    );