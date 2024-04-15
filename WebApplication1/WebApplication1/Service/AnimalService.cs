using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
namespace WebApplication1.Service;

public class AnimalService : IAnimalService
{
    private static List<Animal> Animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Rex", Category = "Dog", Weight = 30.5, FurColor = "Black" },
        new Animal { Id = 2, Name = "Mia", Category = "Cat", Weight = 4.2, FurColor = "White" }
    };

    private static List<Visit> Visits = new List<Visit>
    {
        new Visit { VisitDate = DateTime.Now.AddDays(-10), Animal = Animals[0], Description = "Regular check-up", Price = 50 },
        new Visit { VisitDate = DateTime.Now.AddDays(-5), Animal = Animals[1], Description = "Vaccination", Price = 70 },
        new Visit { VisitDate = DateTime.Now.AddDays(-2), Animal = Animals[0], Description = "Surgery", Price = 150 }
    };

    public List<Animal> GetListAnimal()
    {
        return Animals;
    }
    

    public Animal GetAnimal(int id)
    {
        foreach (var animal in Animals)
        {
            if (animal.Id == id)
            {
                return animal;
            }
        }

        return null;
    }

    public Animal AddAnimal(Animal newAnimal)
    {
        foreach (var animal in Animals)
        {
            if (animal.Id == newAnimal.Id)
            {
                return newAnimal;
            }
        }

        Animals.Add(newAnimal);
        return newAnimal;
    }

    public Animal UpdateAnimal(int id, Animal updatedAnimal)
    {
        foreach (var animal in Animals)
        {
            if (animal.Id == id)
            {
                animal.Name = updatedAnimal.Name;
                animal.Category = updatedAnimal.Category;
                animal.Weight = updatedAnimal.Weight;
                animal.FurColor = updatedAnimal.FurColor;
                return animal;
            }
        }

        return null;
    }

    public void DeleteAnimal(int id)
    {
        Animal animalToRemove = null;
        foreach (var animal in Animals)
        {
            if (animal.Id == id)
            {
                animalToRemove = animal;
                break;
            }
        }

        if (animalToRemove != null)
        {
            Animals.Remove(animalToRemove);
        }
    }

    public List<Visit> GetVisits(int id)
    {
        var animalVisits = new List<Visit>();
        foreach (var visit in Visits)
        {
            if (visit.Animal.Id == id)
            {
                animalVisits.Add(visit);
            }
        }

        return animalVisits;
    }

    public Visit AddVisit(int id, Visit visit)
    {
        foreach (var animal in Animals)
        {
            if (animal.Id == id)
            {
                visit.Animal = animal;
                Visits.Add(visit);
                return visit;
            }
        }

        return null;
    }
}