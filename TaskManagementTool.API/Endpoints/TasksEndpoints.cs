using Microsoft.EntityFrameworkCore;
using TaskManagementTool.Api.Data;
using TaskManagementTool.Api.Dtos;
using TaskManagementTool.Api.Entities;
using TaskManagementTool.Api.Mapping;

namespace TaskManagementTool.Api.Endpoints;

public static class TasksEndpoints
{
    const string GetTaskEndpoint = "GetTask";

    public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("tasks").WithParameterValidation();

        group.MapGet("/", async (TaskContext dbContext) =>
           await dbContext.Tasks
                        .Include(task => task.Category)
                        .Select(task => task.ToDto())
                        .AsNoTracking()
                        .ToListAsync());

        group.MapGet("/{id}", async (int id, TaskContext dbContext ) =>
        {
            TodoTask? task = await dbContext.Tasks.FindAsync(id);

            return task is null ? Results.NotFound() : Results.Ok(task.ToDetailsDto());
        })
          .WithName(GetTaskEndpoint);

    
        group.MapGet("/category/{CategoryId}", async (int categoryId, TaskContext dbContext) =>
          await dbContext.Tasks.Where(t => t.CategoryId == categoryId)
                       .Include(task => task.Category)
                       .Select(task => task.ToDto())
                       .AsNoTracking()
                       .ToListAsync());


        group.MapGet("/completed/{isDone}", async (bool isDone, TaskContext dbContext) =>
            await dbContext.Tasks.Where(t => t.IsDone == isDone)
            .Include(task => task.Category)
            .Select(task => task.ToDto())
            .AsNoTracking()
            .ToListAsync());


        group.MapGet("/{categoryId}/{isDone}", async (int categoryId, bool isDone, TaskContext dbContext) =>
            await dbContext.Tasks.Where(task=>task.CategoryId==categoryId && task.IsDone == isDone)
            .Include(task=>task.Category)
            .Select(task=>task.ToDto())
            .AsNoTracking()
            .ToListAsync());


        group.MapPost("/", async (CreateTaskDto newTask, TaskContext dbContext ) =>
        {
            TodoTask task = newTask.ToEntity();

            dbContext.Tasks.Add(task);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetTaskEndpoint, new { id = task.Id }, task.ToDetailsDto());
        });
        

        group.MapPut("/{id}", async (int id, UpdateTaskDto updatedTask, TaskContext dbContext) =>
        {
            var existingTask = await dbContext.Tasks.FindAsync(id);

            if (existingTask is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingTask).CurrentValues.SetValues(updatedTask.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });


        group.MapDelete("/{id}", async (int id, TaskContext dbContext) =>
        {
           await dbContext.Tasks.Where(task => task.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }

}
