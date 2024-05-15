namespace TaskBoard.App.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Data;
using Models.Home;

public class HomeController : Controller
{
    private readonly TaskBoardAppDbContext _data;

    public HomeController(TaskBoardAppDbContext context)
    {
        _data = context;
    }

    public IActionResult Index()
    {
        var taskBoards = _data.Boards
            .Select(b => b.Name)
            .Distinct()
            .ToList();

        var taskCounts = new List<HomeBoardModel>();

        foreach (var boardName in taskBoards)
        {
            var taskInBoard = _data.Tasks.Where(t => t.Board.Name == boardName).Count();

            taskCounts.Add(new HomeBoardModel
            {
                BoardName = boardName,
                TasksCount = taskInBoard
            });
        }

        var userTasksCount = -1;

        if (User.Identity.IsAuthenticated)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
        }

        var homeModel = new HomeViewModel()
        {
            AllTasksCount = _data.Tasks.Count(),
            BoardsWithTasksCount = taskCounts,
            UserTasksCount = userTasksCount
        };

        return View(homeModel);
    }
}