using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrello.DataTransfer;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;
using Petrello.Pages;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using WebAPI_Task.Models;

namespace Petrello.Pages.Tasks
{
	public class DeleteTModel : PageModel
	{
		public async Task<IActionResult> OnPost(int id)
		{
			HttpClient client = new();
			client.BaseAddress = new Uri("https://localhost:7060"); //adress to API

			using var httpResponseMessage =
				await client.DeleteAsync($"/api/task/{id}");

			httpResponseMessage.EnsureSuccessStatusCode();

			return RedirectToPage("../Index");
		}
	}
}

