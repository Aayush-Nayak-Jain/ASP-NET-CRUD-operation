using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public static class DataExtensions
{
    //method to eliminate the need of running ef database update command
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

}
