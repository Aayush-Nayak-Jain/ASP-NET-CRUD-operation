namespace WebApplication1.DTO;

public record class gamedetailsDTO(
    int Id,
    string Name,
    int  GenreId,
    Decimal Price,
    DateOnly ReleaseDate
    );
