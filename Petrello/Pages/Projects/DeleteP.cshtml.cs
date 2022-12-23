using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Petrello.Pages.Projects
{
    public class DeletePModel : PageModel
    {
		public async Task<IActionResult> OnPost(int id)
		{
			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.DeleteAsync($"/api/project/{id}");

			httpResponseMessage.EnsureSuccessStatusCode();

			return RedirectToPage("../Index");
		}
	}
}
