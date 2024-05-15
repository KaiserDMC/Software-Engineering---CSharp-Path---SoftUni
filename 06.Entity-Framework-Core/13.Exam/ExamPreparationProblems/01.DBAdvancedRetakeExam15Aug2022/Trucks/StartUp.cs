namespace Trucks;

using System;
using System.IO;
using System.Globalization;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Data;

public class StartUp
{
    public static void Main()
    {
        var context = new TrucksContext();

        ResetDatabase(context, shouldDropDatabase: false);

        var projectDir = GetProjectDirectory();

        ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");

        ExportEntities(context, projectDir + @"ExportResults/");

        using (var transaction = context.Database.BeginTransaction())
        {
            transaction.Rollback();
        }
    }

    private static void ImportEntities(TrucksContext context, string baseDir, string exportDir)
    {
        var despatchers =
            DataProcessor.Deserializer.ImportDespatcher(context,
                File.ReadAllText(baseDir + "despatchers.xml"));

        PrintAndExportEntityToFile(despatchers, exportDir + "Actual Result - ImportDespatchers.txt");

        var clients =
       DataProcessor.Deserializer.ImportClient(context,
           File.ReadAllText(baseDir + "clients.json"));

        PrintAndExportEntityToFile(clients, exportDir + "Actual Result - ImportClients.txt");
    }

    private static void ExportEntities(TrucksContext context, string exportDir)
    {
        var ExportDespatchersWithTheirTrucks = DataProcessor.Serializer.ExportDespatchersWithTheirTrucks(context);
        Console.WriteLine(ExportDespatchersWithTheirTrucks);
        File.WriteAllText(exportDir + "Actual Result - ExportDespatchersWithTheirTrucks.xml", ExportDespatchersWithTheirTrucks);

        int tankCapacity = 1000;
        var ExportClientsWithMostTrucks = DataProcessor.Serializer.ExportClientsWithMostTrucks(context, tankCapacity);
        Console.WriteLine(ExportClientsWithMostTrucks);
        File.WriteAllText(exportDir + "Actual Result - ExportClientsWithMostTrucks.json", ExportClientsWithMostTrucks);
    }

    private static void ResetDatabase(TrucksContext context, bool shouldDropDatabase = false)
    {
        if (shouldDropDatabase)
        {
            context.Database.EnsureDeleted();
        }

        if (context.Database.EnsureCreated())
        {
            return;
        }

        var disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
        context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

        var deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
        context.Database.ExecuteSqlRaw(deleteRowsQuery);

        var enableIntegrityChecksQuery =
            "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
        context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

        var reseedQuery =
            "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
        context.Database.ExecuteSqlRaw(reseedQuery);
    }

    private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
    {
        Console.WriteLine(entityOutput);
        File.WriteAllText(outputPath, entityOutput.TrimEnd());
    }

    private static string GetProjectDirectory()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var directoryName = Path.GetFileName(currentDirectory);
        var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

        return relativePath;
    }
}