namespace TaskManagementTool.Api.Entities;

public class TodoTask
{
    public int Id { get; set; }
    public required string Title {  get; set; }
    public int CategoryId { get; set; }
    public required string Description { get; set; }
    public DateOnly DueDate { get; set; }
    public bool IsDone {  get; set; }
    public TimeSpan? TimeSpent { get; set; }
    public Category? Category { get; set; }
}
