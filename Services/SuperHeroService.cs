using SuperHeroAPI.Data;
using SuperHeroAPI;
using Microsoft.EntityFrameworkCore;

public class SuperHeroService : ISuperHeroService
{
    private readonly ISuperHeroRepository _repository;

    public SuperHeroService(ISuperHeroRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SuperHero>> GetHeroes()
    {
        return await _repository.GetHeroes();
    }

    public async Task<SuperHero> GetHeroById(int id)
    {
        return await _repository.GetHeroById(id);
    }

    public async Task<List<SuperHero>> AddHero(SuperHero hero)
    {
        await _repository.AddHero(hero);
        return await _repository.GetHeroes();
    }

    public async Task<List<SuperHero>> UpdateHero(SuperHero request)
    {
        await _repository.UpdateHero(request);
        return await _repository.GetHeroes();
    }

    public async Task<List<SuperHero>> DeleteHero(int id)
    {
        await _repository.DeleteHero(id);
        return await _repository.GetHeroes();
    }
}
