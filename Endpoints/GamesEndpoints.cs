using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Entities;
using WebApplication1.Mapping;

namespace WebApplication1.Endpoints;


public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
{
    var group = app.MapGroup("/games")
                    .WithParameterValidation();

    //query  for games
    group.MapGet("/", async( GameStoreContext dbcontext) =>
        await dbcontext.Games.Include(game => game.Genre)
        .Select(game => game.ToGameSummaryDto())
        .AsNoTracking().ToListAsync());


    // get command to query a game
    group.MapGet("/{id}", async(int id, GameStoreContext dbcontext) =>   
        {
         Game? game = await dbcontext.Games.FindAsync(id);

        return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

    // post command to add a game
    group.MapPost("/", async( creategameDTO newGame ,GameStoreContext dbcontext ) => 
    {
        Game game= newGame.ToEntity();

        dbcontext.Games.Add(game); 
        //Adding entry in db
        await dbcontext.SaveChangesAsync();
        //sending result code with its location
    
        return Results.CreatedAtRoute(GetGameEndpointName,
        new {id = game.Id},
        game.ToGameDetailsDto());
    } 
    );

    //put command to update a game
    group.MapPut("/{id}",async(int id , updategameDTO updatedgame, GameStoreContext dbcontext ) => 
    {
        var existingGame = await dbcontext.Games.FindAsync(id);

        if(existingGame is null )
        {
            return Results.NotFound();
        }

        dbcontext.Entry(existingGame)
            .CurrentValues.SetValues(updatedgame.ToEntity(id));
        await dbcontext.SaveChangesAsync();

        return Results.NoContent();
    });

    //Delete command to delete a game
    group.MapDelete("/{id}",async(int id, GameStoreContext dbcontext) =>
    {
        await dbcontext.Games
            .Where(game => game.Id ==id)
            .ExecuteDeleteAsync();

        return Results.NoContent();
    });
    return group;
    }


}