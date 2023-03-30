using SuperHeroAPI.Data;
using SuperHeroAPI;
using Microsoft.EntityFrameworkCore;

public interface ISuperHeroRepository
{
    Task<List<SuperHero>> GetHeroes();
    Task<SuperHero> GetHeroById(int id);
    Task AddHero(SuperHero hero);
    Task UpdateHero(SuperHero hero);
    Task DeleteHero(int id);
}

public class SuperHeroRepository : ISuperHeroRepository
{
    private readonly DataContext _context;

    public SuperHeroRepository(DataContext context)
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

    public async Task AddHero(SuperHero hero)
    {
        await _context.SuperHeroes.AddAsync(hero);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHero(SuperHero request)
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
    }

    public async Task DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
        {
            throw new Exception("Hero not found");
        }

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
    }

}
