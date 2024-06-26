using TaskManagementTool.Api.Data;
using TaskManagementTool.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Tasks");

builder.Services.AddSqlite<TaskContext>(connectionString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowReactApp");
app.MapTasksEndpoints();
app.MapCategoriesEndpoints();

await app.MigrateDbAsync();

app.Run();
