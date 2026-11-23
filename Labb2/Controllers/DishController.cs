using Labb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Labb2;

namespace Labb2.Controllers
{
    public class DishController : Controller
    {

        public static List<Dish> Dishes = new List<Dish>
        {

            new Dish { DishId = 1, Name = "Pannkakor", Time = 45 },
            new Dish { DishId = 2, Name = "Köttbullar med mos", Time = 130 },
            new Dish { DishId = 3, Name = "Linsgryta", Time = 30 }
        };

        public static List<Diet> Diets = new List<Diet>
        {
            new Diet { DietId = 1, Name = "Gluten" },
            new Diet { DietId = 2, Name = "Vegetariskt" },
            new Diet { DietId = 3, Name = "Veganskt" },

        };



        public IActionResult Index()
        {
            return View(Dishes);

        }

        public IActionResult Create()
        {
            CreateDishViewModel vm = new CreateDishViewModel{AllDiets = Diets, ChosenDiets=new List<Diet>()};

            return View(vm);

 
        }

        [HttpPost]
        public IActionResult Create(CreateDishViewModel vm)
        {
            Dishes.Add(vm);
            return RedirectToAction("Index");
        }


    }
}

