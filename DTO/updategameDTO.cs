using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO;

public record class updategameDTO(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1,100)]Decimal Price,
    DateOnly ReleaseDate
);