namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class StudentCourse
{
    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
}