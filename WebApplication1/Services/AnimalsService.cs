using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalsService : IAnimalsService
{

    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        if (!orderBy.Equals("name") && !orderBy.Equals("description") && !orderBy.Equals("category") &&
            !orderBy.Equals("area"))
        {
            throw new Exception("Wrong parameter.");
        }
        return _animalsRepository.GetAnimals(orderBy);
        
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(int idAnimal, Animal animal)
    {
        return _animalsRepository.UpdateAnimal(idAnimal, animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}