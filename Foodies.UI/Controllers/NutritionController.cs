using Foodies.UI.Models;
using Foodies.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.UI.Controllers
{
    public class NutritionController : Controller
    {
        public NutritionApiService NutritionApiService { get; }

        public NutritionController(NutritionApiService nutritionApiService)
        {
            NutritionApiService = nutritionApiService;
        }
        public async Task<IActionResult> Index()
        {
            var ret = await NutritionApiService.GetNutritionsAsync();
            return View(new NutritionViewModel
            {
                Nutritions = ret
            });

        }
        [HttpGet]
        //GET
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NutritionViewModel model)
        {


            if (ModelState.IsValid)
            {
                await NutritionApiService.CreateNutritionAsync(
                    new Domain.Nutrition
                    {
                        Name = model.Name,
                        Description = model.Description,
                     
                    });
                return RedirectToAction(nameof(Create));
            }
            return View(model);

           
        }




    }
}
