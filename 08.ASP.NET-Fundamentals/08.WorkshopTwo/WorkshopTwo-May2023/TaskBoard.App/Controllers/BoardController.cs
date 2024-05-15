namespace TaskBoard.App.Controllers;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Models.Board;
using TaskBoard.App.Models.Task;
using Data;

public class BoardController : Controller
{
    private readonly TaskBoardAppDbContext _data;

    public BoardController(TaskBoardAppDbContext context)
    {
        _data = context;
    }

    public async Task<IActionResult> All()
    {
        var boards = await _data.Boards
            .Select(b => new BoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks
                    .Where(t => t.BoardId == b.Id)
                    .Select(t => new TaskViewModel()
                    {
                        Id = t.Id.ToString(),
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                    .ToList()
            })
            .ToListAsync();

        return View(boards);
    }
}