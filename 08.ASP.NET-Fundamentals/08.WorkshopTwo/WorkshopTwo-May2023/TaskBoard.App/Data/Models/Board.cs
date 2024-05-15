namespace TaskBoard.App.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants.Board;

public class Board
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(BoardNameMax)]
    public string Name { get; set; } = null!;

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}