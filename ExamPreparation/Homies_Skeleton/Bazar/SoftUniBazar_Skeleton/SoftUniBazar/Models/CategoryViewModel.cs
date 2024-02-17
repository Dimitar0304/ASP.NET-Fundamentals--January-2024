using SoftUniBazar.Data;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models
{
    /// <summary>
    /// Category view model
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Category Idenifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]

        public string Name { get; set; } = null!;
    }
}