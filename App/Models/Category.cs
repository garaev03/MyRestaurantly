using System.ComponentModel.DataAnnotations;

namespace MyRestaurantly.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name cannot be empty!")]
        public string Name { get; set; }
        public List<Menu>? Menu { get; set; }
    }
}
