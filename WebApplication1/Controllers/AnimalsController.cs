using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
        
    
    
    
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        IEnumerable<Animal> animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        

        _animalsService.UpdateAnimal(id, animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        
        _animalsService.DeleteAnimal(id);
        return NoContent();
    }
}