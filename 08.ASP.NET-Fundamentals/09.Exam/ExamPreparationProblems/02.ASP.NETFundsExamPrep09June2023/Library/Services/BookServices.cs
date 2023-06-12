namespace Library.Services;

using Microsoft.EntityFrameworkCore;

using Data;
using Contracts;
using Data.Entities;
using Models.FormModels;
using Models.ViewModels;

public class BookServices : IBookService
{
    private readonly LibraryDbContext _dataContext;

    public BookServices(LibraryDbContext context)
    {
        _dataContext = context;
    }

    public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
    {
        var books = await _dataContext.Books
            .Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category.Name,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
            })
            .ToArrayAsync();

        return books;
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
    {
        var categories = await _dataContext.Categories.ToArrayAsync();

        var categoryModels = categories.Select(c => new CategoryViewModel()
        {
            Id = c.Id,
            Name = c.Name
        });

        return categoryModels;
    }

    public async Task AddBook(BookFromModel model)
    {
        Data.Entities.Book book = new Data.Entities.Book()
        {
            Title = model.Title,
            Author = model.Author,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            Rating = model.Rating,
            CategoryId = model.CategoryId
        };

        await _dataContext.Books.AddAsync(book);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookViewModel>> GetMineBooksAsync(string userId)
    {
        var userBooks = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .Include(b => b.Category)
            .Where(b => b.UsersBooks.Any(u => u.CollectorId == userId))
            .ToListAsync();

        var models = userBooks.Select(b => new BookViewModel()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            ImageUrl = b.ImageUrl,
            Category = b.Category.Name,
            Rating = b.Rating
        });

        return models;
    }

    public async Task AddBookToMine(string userId, int bookId)
    {
        var currentBook = await _dataContext.Books
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (!currentBook.UsersBooks.Any(u => u.CollectorId == userId))
        {
            currentBook.UsersBooks.Add(new IdentityUserBook()
            {
                BookId = bookId,
                CollectorId = userId
            });
        }

        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveBookFromMine(string userId, int bookId)
    {
        var book = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        var userCollection = book.UsersBooks.FirstOrDefault(u => u.CollectorId == userId);

        if (userCollection != null)
        {
            book.UsersBooks.Remove(userCollection);
        }

        await _dataContext.SaveChangesAsync();
    }

    //Optional Edit Functionality

    public async Task<BookEditModel> GetBookById(int bookId)
    {
        var book = await _dataContext.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        var categories = await _dataContext.Categories.ToArrayAsync();

        var categoryModels = categories.Select(c => new CategoryViewModel()
        {
            Id = c.Id,
            Name = c.Name
        });

        if (book != null)
        {
            BookEditModel bookModel = new BookEditModel()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Rating = book.Rating,
                ImageUrl = book.ImageUrl,
                CategoryId = book.CategoryId,
                Categories = categoryModels
            };

            return bookModel;
        }

        return null;
    }

    public async Task UpdateBook(int bookId, BookEditModel model)
    {
        var book = await _dataContext.Books.FindAsync(bookId);

        if (book != null)
        {
            book.Title = model.Title;
            book.Author = model.Author;
            book.Description = model.Description;
            book.Rating = model.Rating;
            book.ImageUrl = model.ImageUrl;
            book.CategoryId = model.CategoryId;
        }

        await _dataContext.SaveChangesAsync();
    }

    //Optional Sorting Functions

    public async Task<IEnumerable<BookViewModel>> SortMineBooksByTitleAscending(string userId)
    {
        var userBooks = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .Include(b => b.Category)
            .Where(b => b.UsersBooks.Any(u => u.CollectorId == userId))
            .ToListAsync();

        var models = userBooks.Select(b => new BookViewModel()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            ImageUrl = b.ImageUrl,
            Category = b.Category.Name,
            Rating = b.Rating
        })
            .OrderBy(b => b.Title);

        return models;
    }

    public async Task<IEnumerable<BookViewModel>> SortMineBooksByTitleDescending(string userId)
    {
        var userBooks = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .Include(b => b.Category)
            .Where(b => b.UsersBooks.Any(u => u.CollectorId == userId))
            .ToListAsync();

        var models = userBooks.Select(b => new BookViewModel()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            ImageUrl = b.ImageUrl,
            Category = b.Category.Name,
            Rating = b.Rating
        })
            .OrderByDescending(b => b.Title);

        return models;
    }

    public async Task<IEnumerable<BookViewModel>> SortMineBooksByCategory(string userId)
    {
        var userBooks = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .Include(b => b.Category)
            .Where(b => b.UsersBooks.Any(u => u.CollectorId == userId))
            .ToListAsync();

        var models = userBooks.Select(b => new BookViewModel()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            ImageUrl = b.ImageUrl,
            Category = b.Category.Name,
            Rating = b.Rating
        })
            .OrderBy(b => b.Category);

        return models;
    }

    public async Task<IEnumerable<BookViewModel>> SortMineBooksByRatingAscending(string userId)
    {
        var userBooks = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .Include(b => b.Category)
            .Where(b => b.UsersBooks.Any(u => u.CollectorId == userId))
            .ToListAsync();

        var models = userBooks.Select(b => new BookViewModel()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            ImageUrl = b.ImageUrl,
            Category = b.Category.Name,
            Rating = b.Rating
        })
            .OrderBy(b => b.Rating);

        return models;
    }

    public async Task<IEnumerable<BookViewModel>> SortMineBooksByRatingDescending(string userId)
    {
        var userBooks = await _dataContext.Books
            .Include(b => b.UsersBooks)
            .Include(b => b.Category)
            .Where(b => b.UsersBooks.Any(u => u.CollectorId == userId))
            .ToListAsync();

        var models = userBooks.Select(b => new BookViewModel()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            ImageUrl = b.ImageUrl,
            Category = b.Category.Name,
            Rating = b.Rating
        })
            .OrderByDescending(b => b.Rating);

        return models;
    }

    //Optional Search Functionality

    public async Task<IEnumerable<BookViewModel>> QuerySearchForTitle(string query)
    {
        var books = await _dataContext.Books
            .Where(b => b.Title.Contains(query) || b.Author.Contains(query))
            .Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category.Name,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
            })
            .ToArrayAsync();

        return books;
    }
}