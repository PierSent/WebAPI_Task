using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrello.DataTransfer;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;

namespace Petrello.Pages.Tasks
{
	public class DeleteTModel : PageModel
	{
		[HttpDelete]
		public async Task<IActionResult> OnPostDelete(int id)
		{
			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.DeleteAsync($"/api/task/{Task.TaskId}");

			httpResponseMessage.EnsureSuccessStatusCode();

			return RedirectToPage("../Index");


		}


		[BindProperty]
		public TaskDto Task { get; set; }
	}
}

