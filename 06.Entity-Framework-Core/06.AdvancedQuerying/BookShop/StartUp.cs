using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop;

using Data;
using Initializer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class StartUp
{
    [SuppressMessage("ReSharper.DPA", "DPA0005: Database issues")]
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        //02.
        //string command = Console.ReadLine();
        //Console.WriteLine(GetBooksByAgeRestriction(db, command));

        //03.
        //Console.WriteLine(GetGoldenBooks(db));

        //04.
        //Console.WriteLine(GetBooksByPrice(db));

        //05.
        //int year = int.Parse(Console.ReadLine()!);
        //Console.WriteLine(GetBooksNotReleasedIn(db, year));

        //06.
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByCategory(db, input));

        //07.
        //string date = Console.ReadLine();
        //Console.WriteLine(GetBooksReleasedBefore(db, date));

        //08.
        //string input = Console.ReadLine();
        //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

        //09.
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBookTitlesContaining(db, input));

        //10.
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByAuthor(db, input));

        //11.
        //int lengthCheck =int.Parse(Console.ReadLine());
        //Console.WriteLine(CountBooks(db, lengthCheck));

        //12.
        //Console.WriteLine(CountCopiesByAuthor(db));

        //13.
        //Console.WriteLine(GetTotalProfitByCategory(db));

        //14.
        //Console.WriteLine(GetMostRecentBooks(db));

        //15.
        //IncreasePrices(db);

        //16.
        //Console.WriteLine(RemoveBooks(db));
    }

    // 02. Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var currentAgeRestriction = Enum.Parse<AgeRestriction>(command, true);

        var books = context.Books
                .Where(b => b.AgeRestriction == currentAgeRestriction)
                .OrderBy(b => b.Title)
                .AsNoTracking()
                .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 03. Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var books = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .AsNoTracking()
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 04. Books By Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var books = context.Books
            .Where(b => b.Price > 40m)
            .OrderByDescending(b => b.Price)
            .AsNoTracking()
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 05. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var books = context.Books
            .Where(b => b.ReleaseDate!.Value.Year != year)
            .OrderBy(b => b.BookId)
            .AsNoTracking()
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 06. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        StringBuilder stringBuilder = new StringBuilder();

        string[] inputSplit = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        var categoryId = context.Categories
            .Where(c => inputSplit.Contains(c.Name.ToLower()))
            .AsNoTracking()
            .Select(c => c.CategoryId)
            .ToArray();

        var books = context.BooksCategories
            .Where(bc => categoryId.Contains(bc.CategoryId))
            .Select(b => b.Book)
            .OrderBy(b => b.Title)
            .AsNoTracking()
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 07. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        StringBuilder stringBuilder = new StringBuilder();

        DateTime dateConverted = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var books = context.Books
            .Where(b => b.ReleaseDate.Value < dateConverted)
            .AsNoTracking()
            .OrderByDescending(b => b.ReleaseDate.Value)
            .Select(b => new
            {
                Title = b.Title,
                Edition = b.EditionType.ToString(),
                Price = b.Price
            })
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:f2}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 08. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName
            })
            .OrderBy(a => a.FullName)
            .AsNoTracking()
            .ToArray();

        foreach (var author in authors)
        {
            stringBuilder.AppendLine($"{author.FullName}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 09. Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var books = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var books = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                Title = b.Title,
                FullName = b.Author.FirstName + " " + b.Author.LastName
            })
            .AsNoTracking()
            .ToArray();

        foreach (var book in books)
        {
            stringBuilder.AppendLine($"{book.Title} ({book.FullName})");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 11. Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        var books = context.Books
            .Where(b => b.Title.Length > lengthCheck)
            .AsNoTracking()
            .ToArray();

        return books.Count();
    }

    // 12. Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var authorBooks = context.Authors
            .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName,
                Copies = a.Books.Sum(x => x.Copies)
            })
            .OrderByDescending(b => b.Copies)
            .AsNoTracking()
            .ToArray();

        foreach (var authorBook in authorBooks)
        {
            stringBuilder.AppendLine($"{authorBook.FullName} - {authorBook.Copies}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 13. Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var profitBooks = context.Categories
            .Select(c => new
            {
                CategoryTitle = c.Name,
                TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
            })
            .OrderByDescending(c => c.TotalProfit)
            .ThenBy(c => c.CategoryTitle)
            .AsNoTracking()
            .ToArray();

        foreach (var profitBook in profitBooks)
        {
            stringBuilder.AppendLine($"{profitBook.CategoryTitle} ${profitBook.TotalProfit:f2}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 14. Most Recent Books
    public static string GetMostRecentBooks(BookShopContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var recentBooks = context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                Category = c.Name,
                Books = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Select(b => new
                    {
                        Title = b.Book.Title,
                        Year = b.Book.ReleaseDate.Value.Year
                    })
                    .Take(3)
                    .ToArray()
            })
            .AsNoTracking()
            .ToArray();

        foreach (var recentBook in recentBooks)
        {
            stringBuilder.AppendLine($"--{recentBook.Category}");

            foreach (var book in recentBook.Books)
            {
                stringBuilder.AppendLine($"{book.Title} ({book.Year})");
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }

    // 15. Increase Prices
    public static void IncreasePrices(BookShopContext context)
    {
        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToArray();

        foreach (var book in books)
        {
            book.Price += 5;
        }

        context.SaveChanges();
    }

    // 16. Remove Books
    public static int RemoveBooks(BookShopContext context)
    {
        var books = context.Books
            .Where(b => b.Copies < 4200)
            .ToArray();

        context.RemoveRange(books);
        context.SaveChanges();

        return books.Length;
    }
}