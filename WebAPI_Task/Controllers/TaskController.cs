using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAPI_Task.Data;
using WebAPI_Task.Models;

namespace WebAPI_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase //managing Http Requests
    {
        //access to the database
        private readonly ProjectDbContext _context;
        public TaskController(ProjectDbContext context) => _context = context;
        
        //a method to get all items from Tasks table
        [HttpGet]
        public async Task<IEnumerable<Models.Task>> Get()
            => await _context.Tasks.ToListAsync();

        //a method to get an item from the table by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(Models.Task), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        //a method to create a new item in the table
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = task.TaskId }, task);
        }

        //a method to edit an existing item in the table by id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Models.Task task)
        {
            if (id != task.TaskId) return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //a method to delete an item from the table by id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            if (taskToDelete == null) return NotFound();

            _context.Tasks.Remove(taskToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
