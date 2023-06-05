namespace TaskBoard.App.Data.Models;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static Data.DataConstants.Task;

public class Task
{
    public Task()
    {
        this.Id = Guid.NewGuid();
    }

    [Required]
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TaskTitleMax)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(TaskDescriptionMax)]
    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int BoardId { get; set; }
    public Board? Board { get; set; }

    [Required]
    public string OwnerId { get; set; } = null!;
    public IdentityUser Owner { get; set; } = null!;
}