using TaskManagementTool.Clients;
using TaskManagementTool.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var taskApiUrl = builder.Configuration["TasksApiUrl"] ?? throw new Exception("TasksApiUrl is not set");

builder.Services.AddHttpClient<TasksClient>(
    client => client.BaseAddress = new Uri(taskApiUrl));

builder.Services.AddHttpClient<CategoryClient>(
    client => client.BaseAddress = new Uri(taskApiUrl));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery(); 

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); 

app.Run();
