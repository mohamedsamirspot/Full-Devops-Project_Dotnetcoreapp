using System.ComponentModel.DataAnnotations;

namespace NewsSite.Models
{
    public class Category
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
