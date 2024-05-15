using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using Common;
using Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ResourceNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Unicode(false)]
    [MaxLength(ValidationConstants.ResourceUrlMaxLength)]
    public string Url { get; set; } = null!;

    [Required]
    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public Course Course { get; set;} = null!;
}