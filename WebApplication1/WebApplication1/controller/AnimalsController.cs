using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.controller;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly List<Animal> _animals = new List<Animal>();

    [HttpGet]
    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    [HttpPost]
    public ActionResult<Animal> CreatAniaml(Animal animal)
    {
        _animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAniaml(int id, Animal animal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
        {
            return NotFound();
        }

        existingAnimal.Name = animal.Name;
        existingAnimal.Typ = animal.Typ;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;

        return NoContent();
    }
}

