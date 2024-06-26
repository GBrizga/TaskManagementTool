
namespace TaskManagementTool.Api.Dtos;

public record class TaskDto(
    int id,
    string Title,
    string Category,
    string Description,
    DateOnly DueDate,
    bool IsDone,
    TimeSpan? TimeSpent
    );
