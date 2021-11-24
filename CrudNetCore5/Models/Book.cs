using System.ComponentModel.DataAnnotations;

namespace CrudNetCore5.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Title is a must")]
        [StringLength(50, ErrorMessage = "{0} lenght must be at least {1}", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is a must")]
        [StringLength(100, ErrorMessage = "{0} lenght must be at least {1}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Release Date is a must")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public System.DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Author is a must")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Price is a must")]
        public int Price { get; set; }

    }
}
