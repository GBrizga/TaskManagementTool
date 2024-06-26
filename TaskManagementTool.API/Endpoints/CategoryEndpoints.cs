using TaskManagementTool.Api.Data;
using TaskManagementTool.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementTool.Api.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("categories");

            group.MapGet("/", async (TaskContext dbContext) =>
                await dbContext.Categories
                                .Select(category => category.ToDto())
                                .AsNoTracking()
                                .ToListAsync());
        return group;
    }
}
