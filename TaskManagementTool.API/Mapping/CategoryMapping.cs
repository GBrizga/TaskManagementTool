using TaskManagementTool.Api.Dtos;
using TaskManagementTool.Api.Entities;


namespace TaskManagementTool.Api.Mapping;

public static class CategoryMapping
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.Id, category.Name);
    }
}
