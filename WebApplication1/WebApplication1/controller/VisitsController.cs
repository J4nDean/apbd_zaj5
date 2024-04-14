using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
using System.Linq;

namespace WebApplication1.controller;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static List<Animal> Animals = new List<Animal>();
    private static List<Visit> Visits = new List<Visit>();

    [HttpGet]
    public ActionResult<List<Animal>> GetAnimals()
    {
        return Animals;
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return animal;
    }

    [HttpPost]
    public ActionResult<Animal> AddAnimal(Animal animal)
    {
        Animals.Add(animal);
        return animal;
    }

    [HttpPut("{id}")]
    public ActionResult<Animal> UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        animal.Name = updatedAnimal.Name;
        animal.Category = updatedAnimal.Category;
        animal.Weight = updatedAnimal.Weight;
        animal.FurColor = updatedAnimal.FurColor;
        return animal;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        Animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id}/visits")]
    public ActionResult<List<Visit>> GetVisits(int id)
    {
        return Visits.Where(v => v.Animal.Id == id).ToList();
    }

    [HttpPost("{id}/visits")]
    public ActionResult<Visit> AddVisit(int id, Visit visit)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        visit.Animal = animal;
        Visits.Add(visit);
        return visit;
    }
}