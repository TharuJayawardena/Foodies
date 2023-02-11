using Foodies.UI.Models;
using Foodies.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Foodies.UI.Controllers
{
    public class FoodController : Controller
    {
       

        public FoodApiService FoodApiService { get; }

        public FoodController(FoodApiService foodApiService)
        {
            FoodApiService = foodApiService;
        }
        public async Task<IActionResult> Index()
        {
            var ret = await FoodApiService.GetFoodsAsync();
            return View(new FoodViewModel
            {
                Foods = ret
            });

        }

        [HttpGet]
       //GET
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodViewModel model)
        {

            if (ModelState.IsValid)
            {
                await FoodApiService.CreateFoodAsync(
                    new Domain.Food
                    {
                        Name = model.Name,
                        Image = model.Image,
                        Price = model.Price,
                    });   
                return RedirectToAction(nameof(Create));
            }
            return View(model);
        }
    }
}
