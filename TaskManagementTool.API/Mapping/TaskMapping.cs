using TaskManagementTool.Api.Dtos;
using TaskManagementTool.Api.Entities;

namespace TaskManagementTool.Api.Mapping;

public static class TaskMapping
{
    public static TodoTask ToEntity(this CreateTaskDto task)
    {
        return new TodoTask()
        {
            Title = task.Title,
            CategoryId = task.CategoryId,
            Description = task.Description,
            DueDate = task.DueDate,
            IsDone = task.IsDone,
            TimeSpent = task.TimeSpent
           
        };
    }

    public static TodoTask ToEntity(this UpdateTaskDto task, int id)
    {
        return new TodoTask()
        {
            Id = id,
            Title = task.Title,
            CategoryId = task.CategoryId,
            Description = task.Description,
            DueDate = task.DueDate,
            IsDone = task.IsDone,
            TimeSpent = task.TimeSpent
           
        };
    }

    public static TaskDto ToDto(this TodoTask task)
    {
            return new(
                task.Id,
                task.Title,
                task.Category!.Name,
                task.Description,
                task.DueDate,
                task.IsDone,
                task.TimeSpent
            );
    }
    public static TaskDetailsDto ToDetailsDto(this TodoTask task)
    {
        return new(
            task.Id,
            task.Title,
            task.CategoryId,
            task.Description,
            task.DueDate,
            task.IsDone,
            task.TimeSpent
            
        );
    }


}
