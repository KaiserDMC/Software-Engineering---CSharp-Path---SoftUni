namespace TaskBoard.App.Models.Task;

public class TaskViewModel
{
    public string Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Owner { get; set; } = null!;
}