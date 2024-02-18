using SeminarHub.Data;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    /// <summary>
    /// Category View Model
    /// </summary>
    public class CategoryViewModel
    {
        /// <summary>
        /// Category identifier
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredTypeErrorMessage)]

        public int Id { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredTypeErrorMessage)]
        [StringLength(DataConstants.CategoryNameMaxLenght
            , MinimumLength = DataConstants.CategoryNameMinLenght
            , ErrorMessage = DataConstants.StringLenghtErrorMessage)]
        public string Name { get; set; } = null!;
    }
}