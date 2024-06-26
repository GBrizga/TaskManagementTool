using TaskManagementTool.Models;

namespace TaskManagementTool.Clients;

public class CategoryClient(HttpClient httpClient)
{
	
	public async Task<Category[]> GetCategoriesAsync()
		=> await httpClient.GetFromJsonAsync<Category[]>("categories") ?? [];

}
