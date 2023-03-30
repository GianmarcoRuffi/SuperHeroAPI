using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI;
using SuperHeroAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepository _repository;

        public SuperHeroController(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            try
            {
                var heroes = await _repository.GetHeroes();
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroById(int id)
        {
            try
            {
                var hero = await _repository.GetHeroById(id);
                if (hero == null)
                {
                    return NotFound();
                }
                return Ok(hero);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            try
            {
                await _repository.AddHero(hero);

                //return Ok(heroes);

                return Ok(await _repository.GetHeroes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            try
            {
                await _repository.UpdateHero(request);

                return Ok(await _repository.GetHeroes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            try
            {
                await _repository.DeleteHero(id);

                return Ok(await _repository.GetHeroes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}











