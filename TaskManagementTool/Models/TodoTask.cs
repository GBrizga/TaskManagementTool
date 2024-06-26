
namespace TaskManagementTool.Models;
public class TodoTask
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required DateOnly DueDate { get; set; }
    public bool IsDone { get; set; }
    public TimeSpan? TimeSpent { get; set; }
}
