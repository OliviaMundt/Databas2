namespace Labb2.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public List<Diet> Diets { get; set; }
    }
}
