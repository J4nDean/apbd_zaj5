using WebApplication1.models;

namespace WebApplication1.Service;

public class AnimalService : IAnimalService.IAnimalService
{
    private static List<Animal> Animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Rex", Category = "Dog", Weight = 30.5, FurColor = "Black" },
        new Animal { Id = 2, Name = "Mia", Category = "Cat", Weight = 4.2, FurColor = "White" }
    };

    private static List<Visit> Visits = new List<Visit>
    {
        new Visit { VisitDate = DateTime.Now.AddDays(-10), Animal = Animals[0], Description = "Regular check-up", Price = 50 },
        new Visit { VisitDate = DateTime.Now.AddDays(-5), Animal = Animals[1], Description = "Vaccination", Price = 70 }
    };

    public List<Animal> GetAnimals()
    {
        return Animals;
    }

    public Animal GetAnimal(int id)
    {
        return Animals.FirstOrDefault(a => a.Id == id);
    }

    public Animal AddAnimal(Animal animal)
    {
        Animals.Add(animal);
        return animal;
    }

    public Animal UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal != null)
        {
            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;
        }
        return animal;
    }

    public void DeleteAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal != null)
        {
            Animals.Remove(animal);
        }
    }

    public List<Visit> GetVisits(int id)
    {
        return Visits.Where(v => v.Animal.Id == id).ToList();
    }

    public Visit AddVisit(int id, Visit visit)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal != null)
        {
            visit.Animal = animal;
            Visits.Add(visit);
        }
        return visit;
    }
}