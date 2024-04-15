using WebApplication1.models;
using System.Collections.Generic;

namespace WebApplication1.Service
{
    public interface IAnimalService
    {
        Animal GetAnimal(int id);
        Animal AddAnimal(Animal newAnimal);
        Animal UpdateAnimal(int id, Animal updatedAnimal);
        void DeleteAnimal(int id);
        List<Visit> GetVisits(int id);
        Visit AddVisit(int id, Visit visit);
    }
}