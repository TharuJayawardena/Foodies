using Foodies.Domain;
using Foodies.Inventory.API.Dto;
using Foodies.Inventory.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Foodies.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public NutritionsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/<NutritionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutrition>>> GetNutrition()
        {
            return await _appDbContext.Nutritions.ToListAsync();
        }

        // GET api/<NutritionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nutrition>> GetNutrition(int id)
        {
          var nutrition = await _appDbContext.Nutritions.FindAsync(id);

            if(nutrition == null)
            {
                return NotFound();
            }
            return Ok(nutrition);
        }

        // POST api/<NutritionsController>
        [HttpPost]
        public async Task<ActionResult<Nutrition>> Post([FromBody] CreateNutritionDto nutrition)
        {
            Nutrition nutritionTemp = new Nutrition()
            {
                Name = nutrition.Name,
                Description = nutrition.Description,
                CreatedAt = DateTime.UtcNow
            };
            await _appDbContext.Nutritions.AddAsync(nutritionTemp);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetNutrition),
                new { id = nutritionTemp.Id},
                nutrition
                );
        }

        // PUT api/<NutritionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateNutritionDto nutrition)
        {
            var nutritionTemp = await _appDbContext.Nutritions.FindAsync(id);
            if(nutritionTemp == null)
            {
                return NotFound();
            }
            nutritionTemp.Name = nutrition.Name;
            nutritionTemp.Description = nutrition.Description;
            nutritionTemp.ModifiedAt = DateTime.UtcNow;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch
            {
                return NotFound();
            }
            return NoContent();
        }
        private bool NutrtionsExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<NutritionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nutrition = await _appDbContext.Nutritions.FindAsync(id);
            if(nutrition == null)
            {
                return NotFound();
            }
            _appDbContext.Nutritions.Remove(nutrition);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool NutritionsExists(long id)
        {
            return _appDbContext.Nutritions.Any(e => e.Id == id);
        }
    }
}
