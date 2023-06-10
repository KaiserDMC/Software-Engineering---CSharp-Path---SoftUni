using System.Security.Claims;

namespace Library.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Contracts;
using Library.Models.FormModels;

[Authorize]
public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> All()
    {
        var books = await _bookService.GetAllBooksAsync();

        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var categories = await _bookService.GetAllCategoriesAsync();

        BookFromModel bookModel = new BookFromModel()
        {
            Categories = categories
        };

        return View(bookModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookFromModel bookModel)
    {
        if (!ModelState.IsValid)
        {
            return View(bookModel);
        }

        await _bookService.AddBook(bookModel);

        return RedirectToAction("All", "Book");
    }

    public async Task<IActionResult> Mine()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var books = await _bookService.GetMineBooksAsync(userId);

        return View(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCollection(int id)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        try
        {
            await _bookService.AddBookToMine(userId, id);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("All", "Book");
    }

    public async Task<IActionResult> RemoveFromCollection(int id)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        try
        {
            await _bookService.RemoveBookFromMine(userId, id);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("Mine", "Book");
    }

    //Optional Edit Functionality

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var bookModel = await _bookService.GetBookById(id);

        if (bookModel == null)
        {
            return NotFound();
        }

        return View(bookModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, BookEditModel bookModel)
    {
        if (!ModelState.IsValid)
        {
            return View(bookModel);
        }

        try
        {
            await _bookService.UpdateBook(id, bookModel);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("All", "Book");
    }
}