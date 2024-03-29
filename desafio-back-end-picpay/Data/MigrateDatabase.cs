﻿using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace desafio_back_end_picpay.Data;

public static class MigrateDatabase
{
    public static void MigrateDb(string connection)
    {
        try
        {
            var evolveConnection = new SqlConnection(connection);
            var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
            {
                Locations = new List<string> { "Data/DB/migrations", "Data/db/dataset" },
                IsEraseDisabled = true,
            };
            evolve.Migrate();
        }
        catch (Exception ex)
        {
            Log.Error("Database migration failed", ex);
            throw;
        }
    }
}
