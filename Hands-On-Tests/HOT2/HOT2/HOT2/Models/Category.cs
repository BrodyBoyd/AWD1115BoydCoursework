using System.ComponentModel.DataAnnotations;

namespace HOT2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a Category Name")]
        public string CategoryName { get; set; }
    }
}
