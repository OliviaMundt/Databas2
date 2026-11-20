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

            new Dish { FoodId = 1, Name = "Pannkakor", Time = 45 },
            new Dish { FoodId = 2, Name = "Köttbullar med mos", Time = 130 },
            new Dish { FoodId = 3, Name = "Linsgryta", Time = 30 }
        };
   

        public IActionResult Index()
        {
            return View(Dishes);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dish nyttRecept)
        {
            Dishes.Add(nyttRecept);
            return RedirectToAction("Index");
        }


    }
}

