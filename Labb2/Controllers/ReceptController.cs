using Labb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Labb2;

namespace Labb2.Controllers
{
    public class ReceptController : Controller
    {

        public static List<Food> FoodList = new List<Food>
        {

            new Food { FoodId = 1, Name = "Pannkakor", Time = 45 },
            new Food { FoodId = 2, Name = "Köttbullar med mos", Time = 130 },
            new Food { FoodId = 3, Name = "Linsgryta", Time = 30 }
        };
   

        public IActionResult Index()
        {
            return View(FoodList);

        }

        public IActionResult CreateFood()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFood(Food nyttRecept)
        {
            FoodList.Add(nyttRecept);
            return RedirectToAction("Index");
        }


    }
}

