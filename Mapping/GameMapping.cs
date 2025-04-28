using System;
using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this creategameDTO game)
    {
        return new Game(){
        Name =game.Name,
        GenreId = game.GenreId, 
        Price = game.Price,
        ReleaseDate = game.ReleaseDate
        };
    }

    public static Game ToEntity(this updategameDTO game, int id)
    {
        return new Game(){
        Id=id,
        Name =game.Name,
        GenreId = game.GenreId, 
        Price = game.Price,
        ReleaseDate = game.ReleaseDate
        };
    }

    public static gamesummaryDTO ToGameSummaryDto(this Game game)
    {
        return new (
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }

    public static gamedetailsDTO ToGameDetailsDto(this Game game)
    {
        return new (
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }
}
