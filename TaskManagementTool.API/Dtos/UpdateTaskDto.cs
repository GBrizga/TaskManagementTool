using System.ComponentModel.DataAnnotations;

namespace TaskManagementTool.Api.Dtos;

public record class UpdateTaskDto(
    [Required] string Title,
    int CategoryId,
    [Required][StringLength(499)] string Description,
    [Required] DateOnly DueDate,
    bool IsDone,
    TimeSpan? TimeSpent
    );

