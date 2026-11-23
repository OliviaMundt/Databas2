using Labb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Labb2;

namespace Labb2.Controllers
{
    public class DishController : Controller
    {

        private List<Dish> GetDishes()
        {
            var dishes = HttpContext.Session.GetObject<List<Dish>>("DishList");

            if (dishes == null)
            {
                dishes = new List<Dish>
                {
                    new Dish
                    {
                        DishId = 1,
                        Name = "Pannkakor",
                        Time = 45,
                        Diets = new List<Diet> { Diets[0], Diets[1] }
                    },
                    new Dish
                    {
                        DishId = 2,
                        Name = "Köttbullar med mos",
                        Time = 130,
                        Diets = new List<Diet> { Diets[0] }
                    },

                    new Dish
                    {
                        DishId = 3,
                        Name = "Linsgryta",
                        Time = 30,
                        Diets = new List<Diet> { Diets[1], Diets[2] }
                    }
                };

                HttpContext.Session.SetObject("DishList", dishes);
            }

            return dishes;
        }

        public static List<Diet> Diets = new List<Diet>
        {
            new Diet { DietId = 1, Name = "Gluten" },
            new Diet { DietId = 2, Name = "Vegetariskt" },
            new Diet { DietId = 3, Name = "Veganskt" },

        };



        public IActionResult Index()
        {
            return View(GetDishes());

        }

        public IActionResult Create()
        {
            CreateDishViewModel vm = new CreateDishViewModel
            {
                AllDiets = Diets,
                ChosenDiets = new List<int>()
            };

            return View(vm);


        }

        [HttpPost]
        public IActionResult Create(CreateDishViewModel vm)
        {
            List<Dish> dishes = GetDishes();

            var selectedDiets = Diets.Where(d => vm.ChosenDiets.Contains(d.DietId)).ToList();

            Dish newDish = new Dish
            {
                DishId = dishes.Count + 1,
                Name = vm.Name,
                Time = vm.Time,
                Diets = selectedDiets
            };

            dishes.Add(newDish);
            HttpContext.Session.SetObject("DishList", dishes);

            return RedirectToAction("Index");
        }

        public IActionResult Plan()
        {
            ViewData["Rubrik"] = "Planera din matlagning";
            return View(GetDishes());
        }

        [HttpPost]
        public IActionResult Plan()
        {
            return View(GetDishes());
        }

    }

}

