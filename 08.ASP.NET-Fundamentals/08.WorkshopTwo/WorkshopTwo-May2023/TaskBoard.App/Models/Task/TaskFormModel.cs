namespace TaskBoard.App.Models.Task;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants;

public class TaskFormModel
{
    [Required]
    [StringLength(Task.TaskTitleMax, MinimumLength = Task.TaskDescriptionMin, ErrorMessage = "Title should be at least {2} characters long.")]
    public string Title { get; set; }

    [Required]
    [StringLength(Task.TaskDescriptionMax, MinimumLength = Task.TaskDescriptionMin, ErrorMessage = "Description should be at least {2} characters long.")]
    public string Description { get; set; }

    [Display(Name = "Board")]
    public int BoardId { get; set; }

    public ICollection<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
}