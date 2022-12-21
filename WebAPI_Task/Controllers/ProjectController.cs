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
    public class ProjectController : ControllerBase //managing Http Requests
    {
        //access to the database
        private readonly ProjectDbContext _context;
        public ProjectController(ProjectDbContext context) => _context = context;

        //a method to get all items from Projects table
        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
            => await _context.Projects.ToListAsync();

        //a method to get an item from the table by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            return project == null ? NotFound() : Ok(project);
        }

        //a method to create a new item in the table
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);
        }

        //a method to edit an existing item in the table by id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Project project)
        {
            if (id != project.ProjectId) return BadRequest();

            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //a method to delete an item from the table by id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);
            if (projectToDelete == null) return NotFound();

            _context.Projects.Remove(projectToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
