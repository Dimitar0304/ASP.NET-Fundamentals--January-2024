using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{
    [Comment("AdBuyer data type")]
    public class AdBuyer
    {
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [ForeignKey(nameof(Buyer))]
        [Comment("Buyer identifier")]
        public string BuyerId { get; set; } = null!;
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]
        [Comment("Buyer")]
        public IdentityUser Buyer { get; set; } = null!;
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [ForeignKey(nameof(Ad))]
        [Comment("Ad Identifier")]
        public int AdId { get; set; }
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]
        [Comment("Ad")]
        public Ad Ad { get; set; } = null!;

    }
}
