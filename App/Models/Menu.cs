using Microsoft.Build.Framework;

namespace MyRestaurantly.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Path { get; set; }
        public int CategoryId { get; set; }
        public int IngredientId { get; set; }
        public Category? Category { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

    }
}
