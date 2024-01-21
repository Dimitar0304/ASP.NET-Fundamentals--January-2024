using System.ComponentModel.DataAnnotations;

namespace MVCIntroDemo.ViewModels
{
    /// <summary>
    /// Product view model
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        [StringLength(50)]

        public string Name { get; set; } = null!;
        /// <summary>
        /// Product price
        /// </summary>
        [Required]

        public decimal Price { get; set; }
    }
}
