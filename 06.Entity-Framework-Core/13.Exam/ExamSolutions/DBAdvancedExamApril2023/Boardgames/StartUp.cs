namespace Boardgames;

using Microsoft.EntityFrameworkCore;
using Boardgames.Data;

public class StartUp
{
    public static void Main()
    {
        var context = new BoardgamesContext();

        ResetDatabase(context, shouldDropDatabase: true);

        var projectDir = GetProjectDirectory();

        ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");

        ExportEntities(context, projectDir + @"ExportResults/");

        using (var transaction = context.Database.BeginTransaction())
        {
            transaction.Rollback();
        }
    }

    private static void ImportEntities(BoardgamesContext context, string baseDir, string exportDir)
    {
        var creators =
            DataProcessor.Deserializer.ImportCreators(context,
                File.ReadAllText(baseDir + "creators.xml"));

        PrintAndExportEntityToFile(creators, exportDir + "Actual Result - ImportCreators.txt");

        var sellers =
         DataProcessor.Deserializer.ImportSellers(context,
             File.ReadAllText(baseDir + "sellers.json"));

        PrintAndExportEntityToFile(sellers, exportDir + "Actual Result - ImportSellers.txt");
    }

    private static void ExportEntities(BoardgamesContext context, string exportDir)
    {
        var exportCreatorsWithTheirBoardgames = DataProcessor.Serializer.ExportCreatorsWithTheirBoardgames(context);
        Console.WriteLine(exportCreatorsWithTheirBoardgames);
        File.WriteAllText(exportDir + "Actual Result - ExportCreatorsWithTheirBoardgames.xml", exportCreatorsWithTheirBoardgames);

        var year = 2021;
        double rating = 9.50;
        var exportSellersWithMostBoardgames = DataProcessor.Serializer.ExportSellersWithMostBoardgames(context, year, rating);
        Console.WriteLine(exportSellersWithMostBoardgames);
        File.WriteAllText(exportDir + "Actual Result - ExportSellersWithMostBoardgames.json", exportSellersWithMostBoardgames);
    }

    private static void ResetDatabase(BoardgamesContext context, bool shouldDropDatabase = false)
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