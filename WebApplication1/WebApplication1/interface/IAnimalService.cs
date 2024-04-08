using WebApplication1.models;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimal(int id);
    Animal CreateAnimal(Animal animal);
    Animal UpdateAnimal(int id, Animal animal);
    void DeleteAnimal(int id);
}