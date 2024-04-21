using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string s);

    int CreateAnimal(Animal animal);

    int UpdateAnimal(int idAnimal, Animal animal);

    int DeleteAnimal(int idAnimal);
}