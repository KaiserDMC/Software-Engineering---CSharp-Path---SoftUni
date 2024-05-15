namespace TaskBoard.App.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using Data;
using TaskBoard.App.Models.Task;

[Authorize]
public class TaskController : Controller
{
    private readonly TaskBoardAppDbContext _data;

    public TaskController(TaskBoardAppDbContext context)
    {
        _data = context;
    }

    public async Task<IActionResult> Create()
    {
        TaskFormModel taskFormModel = new TaskFormModel()
        {
            Boards = GetBoards()
        };

        return View(taskFormModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormModel taskFormModel)
    {
        if (!GetBoards().Any(b => b.Id == taskFormModel.BoardId))
        {
            ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist.");
        }

        string currentUserId = GetUserId();

        if (!ModelState.IsValid)
        {
            taskFormModel.Boards = GetBoards();

            return View(taskFormModel);
        }

        Data.Models.Task task = new Data.Models.Task()
        {
            Title = taskFormModel.Title,
            Description = taskFormModel.Description,
            CreatedOn = DateTime.Now,
            BoardId = taskFormModel.BoardId,
            OwnerId = currentUserId
        };

        await _data.Tasks.AddAsync(task);
        await _data.SaveChangesAsync();

        var boards = _data.Boards;

        return RedirectToAction("All", "Board");
    }

    public async Task<IActionResult> Details(string id)
    {
        var task = await _data.Tasks
            .Where(t => t.Id.ToString() == id)
            .Select(t => new TaskDetailsViewModel()
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                Board = t.Board.Name,
                Owner = t.Owner.UserName
            })
            .FirstOrDefaultAsync();

        if (task == null)
        {
            return BadRequest();
        }

        return View(task);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var task = await _data.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        TaskFormModel taskFormModel = new TaskFormModel()
        {
            Title = task.Title,
            Description = task.Description,
            BoardId = task.BoardId,
            Boards = GetBoards()
        };

        return View(taskFormModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, TaskFormModel taskFormModel)
    {
        var task = await _data.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        if (!GetBoards().Any(b => b.Id == taskFormModel.BoardId))
        {
            ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist.");
        }

        if (!ModelState.IsValid)
        {
            taskFormModel.Boards = GetBoards();

            return View(taskFormModel);
        }

        task.Title = task.Title;
        task.Description = task.Description;
        task.BoardId = taskFormModel.BoardId;

        await _data.SaveChangesAsync();

        return RedirectToAction("All", "Board");
    }

    public async Task<IActionResult> Delete(string id)
    {
        var task = await _data.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        TaskViewModel taskModel = new TaskViewModel()
        {
            Id = task.Id.ToString(),
            Title = task.Title,
            Description = task.Description,
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaskViewModel taskViewModel)
    {
        var task = await _data.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == taskViewModel.Id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        _data.Tasks.Remove(task);
        await _data.SaveChangesAsync();

        return RedirectToAction("All", "Board");
    }

    private ICollection<TaskBoardModel> GetBoards()
        => _data.Boards.Select(b => new TaskBoardModel()
        {
            Id = b.Id,
            Name = b.Name
        })
            .ToList();

    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
}