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
}