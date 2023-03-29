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
        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            try
            {
                var heroes = await _service.GetHeroes();
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
                var hero = await _service.GetHeroById(id);
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
                var heroes = await _service.AddHero(hero);
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero heroToUpdate)
        {
            try
            {
                var heroes = await _service.UpdateHero(heroToUpdate);
                return Ok(heroes);
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
                var heroes = await _service.DeleteHero(id);
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}











