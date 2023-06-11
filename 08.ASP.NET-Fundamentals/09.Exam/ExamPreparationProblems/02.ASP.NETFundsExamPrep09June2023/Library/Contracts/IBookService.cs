namespace Library.Contracts;

using Models.FormModels;
using Models.ViewModels;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllBooksAsync();

    Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

    Task AddBook(BookFromModel model);

    Task<IEnumerable<BookViewModel>> GetMineBooksAsync(string userId);

    Task AddBookToMine(string userId, int bookId);

    Task RemoveBookFromMine(string userId, int bookId);

    //Optional Edit Functionality
    Task<BookEditModel> GetBookById(int bookId);

    Task UpdateBook(int bookId, BookEditModel model);

    //Optional Sorting Functionality

    Task<IEnumerable<BookViewModel>> SortMineBooksByTitleAscending(string userId);
    Task<IEnumerable<BookViewModel>> SortMineBooksByTitleDescending(string userId);
    Task<IEnumerable<BookViewModel>> SortMineBooksByCategory(string userId);
    Task<IEnumerable<BookViewModel>> SortMineBooksByRatingAscending(string userId);
    Task<IEnumerable<BookViewModel>> SortMineBooksByRatingDescending(string userId);

    //Optional Search Functionality
    Task<IEnumerable<BookViewModel>> QuerySearchForTitle(string query);
}