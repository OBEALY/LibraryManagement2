using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _service;

    public AuthorsController(AuthorService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await _service.GetByIdAsync(id);
        return author == null ? NotFound() : Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        try
        {
            var created = await _service.AddAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Author author)
    {
        if (id != author.Id) return BadRequest("ID mismatch");

        try
        {
            if (!await _service.UpdateAsync(author)) return NotFound();
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }

    [HttpGet("with-book-count")]
    public async Task<IActionResult> GetAuthorsWithBookCount() =>
        Ok(await _service.GetAuthorsWithBookCountAsync());

    [HttpGet("search/{name}")]
    public async Task<IActionResult> FindByName(string name) =>
        Ok(await _service.FindByNameAsync(name));
}