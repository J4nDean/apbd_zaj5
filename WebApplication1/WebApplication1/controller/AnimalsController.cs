using Microsoft.AspNetCore.Mvc;
using WebApplication1.IAnimalService;
using WebApplication1.models;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animal = _animalService.GetAnimal(id);
        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    [HttpPost]
    public ActionResult<Animal> AddAnimal(Animal animal)
    {
        return _animalService.AddAnimal(animal);
    }

    [HttpPut("{id}")]
    public ActionResult<Animal> UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = _animalService.UpdateAnimal(id, updatedAnimal);
        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
        _animalService.DeleteAnimal(id);
        return NoContent();
    }

    [HttpGet("{id}/visits")]
    public ActionResult<List<Visit>> GetVisits(int id)
    {
        return _animalService.GetVisits(id);
    }

    [HttpPost("{id}/visits")]
    public ActionResult<Visit> AddVisit(int id, Visit visitParam)
    {
        var visit = _animalService.AddVisit(id, visitParam);
        if (visit == null)
        {
            return NotFound();
        }

        return visit;
    }
}