using Microsoft.Build.Framework;

namespace MyRestaurantly.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Menu? menu { get; set; }
    }
}
