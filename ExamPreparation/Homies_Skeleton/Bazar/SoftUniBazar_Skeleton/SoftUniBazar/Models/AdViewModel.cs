using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models
{
    /// <summary>
    /// Ad view model
    /// </summary>
    public class AdViewModel
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
        public string Description { get; set; }=null!;
        /// <summary>
        /// Ad Creation date
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]
        public string CreatedOn { get; set; } = null!;
        /// <summary>
        /// Ad Seller
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]    
        
        public string Owner { get; set; } = null !;
        /// <summary>
        /// Ad Category
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public string Category { get; set; } = null!;
        /// <summary>
        /// Ad Price
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]
        public decimal Price { get; set; }
        /// <summary>
        /// Ad ImageUrl
        /// </summary>
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]

        public string ImageUrl { get; set; } = null!;
        /// <summary>
        /// Owner email for View
        /// </summary>
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]
        public string OwnerEmail = null!;
    }
}
