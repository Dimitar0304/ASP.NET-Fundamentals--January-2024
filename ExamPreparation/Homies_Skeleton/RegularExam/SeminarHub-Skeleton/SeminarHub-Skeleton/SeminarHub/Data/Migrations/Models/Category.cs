using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SeminarHub.Data.Migrations.Models
{
    [Comment("Category data entity")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.CategoryNameMaxLenght)]
        [Comment("Category Name")]
        public string Name { get; set; } = null!;
        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Name – string with min length 3 and max length 50 (required)
//⦁	Has Seminars – a collection of type Seminar
