using TaskManagementTool.Models;

namespace TaskManagementTool.Clients;

public class TasksClient(HttpClient httpClient)
{
   
    public async Task<TodoTask[]> GetTasksAsync()
		=> await httpClient.GetFromJsonAsync<TodoTask[]>("tasks") ?? [];

	public async Task AddTaskAsync(TaskDetails task)
		=> await httpClient.PostAsJsonAsync("tasks", task);

	public async Task<TaskDetails> GetTaskAsync(int id)
		=> await httpClient.GetFromJsonAsync<TaskDetails>($"tasks/{id}")
		?? throw new Exception("Could not find task");

    public async Task<TodoTask[]> GetTasksByCategoryAsync(int id)
        => await httpClient.GetFromJsonAsync<TodoTask[]>($"tasks/category/{id}")
        ?? throw new Exception("Could not find task");

    public async Task<TodoTask[]> GetTasksByStatusAsync(bool isDone)
       => await httpClient.GetFromJsonAsync<TodoTask[]>($"tasks/completed/{isDone}")
       ?? throw new Exception("Could not find task");

    public async Task<TodoTask[]> GetTasksByStatusAndCategoryAsync(int id,bool isDone)
       => await httpClient.GetFromJsonAsync<TodoTask[]>($"tasks/{id}/{isDone}")
       ?? throw new Exception("Could not find task");

    public async Task UpdateTaskAsync(TaskDetails updatedTask)
		=> await httpClient.PutAsJsonAsync($"tasks/{updatedTask.Id}", updatedTask);

	public async Task DeleteTaskAsync(int id)
		=> await httpClient.DeleteAsync($"tasks/{id}");
	

}
