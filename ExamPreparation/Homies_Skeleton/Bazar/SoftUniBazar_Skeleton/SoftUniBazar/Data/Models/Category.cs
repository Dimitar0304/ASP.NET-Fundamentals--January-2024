using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SoftUniBazar.Data.Models
{
    [Comment("Category data type")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DataConstants.CategoryNameMaxLenght)]
        [Comment("Category Name")]
        public string Name { get; set; } = null!;
        public IEnumerable<Ad> Ads { get; set; } = new List<Ad>();
    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Name – a string with min length 3 and max length 15 (required)
//⦁	Has Ads – a collection of type Ad
