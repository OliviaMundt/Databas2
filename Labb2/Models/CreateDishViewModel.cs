namespace Labb2.Models
{
    public class CreateDishViewModel
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public List<Diet> AllDiets { get; set; }

        public List<int> ChosenDiets { get; set; } = new List<int>();

    }
}
