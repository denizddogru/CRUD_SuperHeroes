using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Models;


namespace SuperheroAPI.Controllers
{


    [Route("api/hero/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {

        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    FirstName = "Deniz",
                    LastName = "Doğru",
                    HeroName = "Omni",
                    City = "Antalya"
                },

                new SuperHero
                {
                    Id = 2,
                    FirstName = "kedi-1",
                    LastName = "Ilıca",
                    HeroName = "Cafi",
                    City = "Gayrettepe"
                },

                new SuperHero
                {
                    Id = 3,
                    FirstName = "kedi-2",
                    LastName = "Ilıca",
                    HeroName = "Yakup",
                    City = "Gayrettepe"
                }


             };
        [HttpGet]
        //ActionResult yaptığımızda, of type List dedik, ve SuperHero'classınındaki attributelarla action oluşturduk.
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get_by_id(int id)
        {
            // var hero = heroes[id];
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }
            else
            {
                return Ok(hero);
            }
        }

        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHeroes(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        //Change hero
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHeroes(SuperHero request_hero)
        {
            // we need to override the properties

            var hero = heroes.Find(h => h.Id == request_hero.Id);

            if (hero == null)
                return BadRequest("Hero not found!");

            hero.HeroName = request_hero.HeroName;
            hero.FirstName = request_hero.FirstName;
            hero.LastName = request_hero.LastName;
            hero.City = request_hero.City;

            return Ok(heroes);

        }
    }
}
