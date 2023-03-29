using SuperHeroAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetHeroes();
    Task<SuperHero> GetHeroById(int id);
    Task<List<SuperHero>> AddHero(SuperHero hero);
    Task<List<SuperHero>> UpdateHero(SuperHero hero);
    Task<List<SuperHero>> DeleteHero(int id);
}