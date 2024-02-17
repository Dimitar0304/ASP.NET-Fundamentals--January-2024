using SoftUniBazar.Data;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models
{
    public class AdFormViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Ad Name
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DataConstants.AdMaxNameLenght,
            MinimumLength = DataConstants.AdMinNameLenght,
            ErrorMessage = DataConstants.StringLenghtErrorMessage)]

        public string Name { get; set; } = null!;
        /// <summary>
        /// Ad Description
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DataConstants.AdMaxDescriptionLength,
       MinimumLength = DataConstants.AdMinDescriptionLenght,
       ErrorMessage = DataConstants.StringLenghtErrorMessage)]
        public string Description { get; set; } = null!;
        /// <summary>
        /// Ad Creation date
        /// </summary>
        
        public string CreatedOn { get; set; } = null!;
   
        /// <summary>
        /// Ad CategoryId
        /// </summary>
       
        public int CategoryId { get; set; } 
        /// <summary>
        /// Ad Price
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public decimal Price { get; set; }
        /// <summary>
        /// Ad image url
        /// </summary>

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public string ImageUrl { get; set; } = null!;
        /// <summary>
        /// Ad Categories set
        /// </summary>
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
