using Foodies.Domain;
using Foodies.Inventory.API.Dto;
using Foodies.Inventory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodies.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly AppDbContext _foodContext;

        public FoodsController(AppDbContext foodContext)
        {
            _foodContext = foodContext;
        }


        // GET: api/<FoodsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFood()
        {
            return await _foodContext.Foods.ToListAsync();
        }

        // GET api/<FoodsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var food = await _foodContext.Foods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        // POST api/<FoodsController>
        [HttpPost]
        public async Task<ActionResult<Food>> Post([FromBody] CreateFoodDto food)
        {
            Food foodTemp = new Food()
            {
                Name = food.Name,
                Image = food.Image,
                Price = food.Price,
                CreatedAt = DateTime.UtcNow
            };
           await _foodContext.Foods.AddAsync(foodTemp);
            await _foodContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFood),
                new { id = foodTemp.Id },
                food
                );
        }

        // PUT api/<FoodsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateFoodDto food)
        {
            var foodTemp = await _foodContext.Foods.FindAsync(id);
            if (foodTemp == null)
            {
                return NotFound();
            }
            foodTemp.Name = food.Name;
            foodTemp.Image = food.Image;
            foodTemp.Price = food.Price;
            foodTemp.ModifiedAt = DateTime.UtcNow;

            try
            {
                await _foodContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FoodExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool FoodExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<FoodsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _foodContext.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            _foodContext.Foods.Remove(food);
            await _foodContext.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(long id)
        {
            return _foodContext.Foods.Any(e => e.Id == id);
        }

    }
}
