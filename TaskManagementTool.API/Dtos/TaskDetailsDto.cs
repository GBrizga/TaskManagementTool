
namespace TaskManagementTool.Api.Dtos;

public record class TaskDetailsDto(
    int id,
    string Title,
    int CategoryId,
    string Description,
    DateOnly DueDate,
    bool IsDone,
    TimeSpan? TimeSpent
    );
