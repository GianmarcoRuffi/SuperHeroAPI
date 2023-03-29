using SuperHeroAPI.Data;
using SuperHeroAPI;
using Microsoft.EntityFrameworkCore;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetHeroes()
    {
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero> GetHeroById(int id)
    {
        return await _context.SuperHeroes.FindAsync(id);
    }

    public async Task<List<SuperHero>> AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>> UpdateHero(SuperHero request)
    {
        var DbHero = await _context.SuperHeroes.FindAsync(request.Id);
        if (DbHero == null)
        {
            throw new Exception("Hero not found");
        }

        DbHero.Name = request.Name;
        DbHero.FirstName = request.FirstName;
        DbHero.LastName = request.LastName;
        DbHero.Place = request.Place;

        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>> DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
        {
            throw new Exception("Hero not found");
        }

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }


}