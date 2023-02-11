//using Foodies.Inventory.API.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Foodies.Inventory.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FoodNutritionsController : ControllerBase
//    {
//        private readonly AppDbContext _foodNutritionContext;
//        private AppDbContext? foodNutritionContext;

//        public FoodNutritionsController()
//        {
//            _foodNutritionContext = foodNutritionContext;
//        }
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Nutrition>>> GetNutrition()
//        {
//            return await _foodNutritionContext.FoodNutritions.ToListAsync();
//        }

//        // GET api/<FoodNutritionsController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<FoodNutritionsController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<FoodNutritionsController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<FoodNutritionsController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
