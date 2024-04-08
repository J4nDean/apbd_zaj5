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

    [HttpGet]
    public ActionResult<Animal> GetAniaml(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }
}