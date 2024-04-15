using WebApplication1.models;

namespace WebApplication1.IAnimalService;

public interface IAnimalService
{
    List<Animal> GetAnimals();
    Animal GetAnimal(int id);
    Animal AddAnimal(Animal animal);
    Animal UpdateAnimal(int id, Animal updatedAnimal);
    void DeleteAnimal(int id);
    List<Visit> GetVisits(int id);
    Visit AddVisit(int id, Visit visit);
}