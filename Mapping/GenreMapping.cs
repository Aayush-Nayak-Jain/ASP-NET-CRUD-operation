using System;
using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Mapping;

public static class GenreMapping
{
    public static genreDTO ToDto(this Genre genre)
    {
        return new genreDTO(genre.Id, genre.Name);
    }
}
