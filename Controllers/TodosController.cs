using Microsoft.AspNetCore.Mvc;
using SensorApi.Services;
using SensorApi.Models;
using System;

namespace SensorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly TodosService _todosService;
    public TodosController(TodosService todosService) =>
        _todosService = todosService;
    
    [HttpGet]
    public async Task<List<Todo>> Get() =>
        await _todosService.GetAsync();

    [HttpPost]
    public async Task<IActionResult> Post(Todo newTodo)
    {
        Console.WriteLine(newTodo);
        await _todosService.CreateAsync(newTodo);

        return CreatedAtAction(nameof(Get), new { id = newTodo.Id }, newTodo);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string Id) 
    {
        var todo = await _todosService.GetAsync(Id);

        if (todo is null)
            return NotFound();

        await _todosService.RemoveAsync(Id);

        return NoContent();
    }
}