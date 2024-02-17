using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace SoftUniBazar.Data.Models
{
    [Comment("Add data entity")]
    public class Ad
    {
        [Key]
        [Comment("Add identifier")]
        public int Id { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DataConstants.AdMaxNameLenght)]
        [Comment("Ad Name")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DataConstants.AdMaxDescriptionLength)]
        [Comment("Ad Description")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Comment("Ad Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Comment("Ad Owner identifier")]
        [ForeignKey(nameof(OwnerId))]
        public string OwnerId { get; set; } = null!;
        [Required]
        [Comment("Ad Owner")]
        public IdentityUser Owner { get; set; } = null!;
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Comment("Ad Image")]
        public string ImageUrl { get; set; } = null!;
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Comment("Ad Creation date")]
        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage =DataConstants.RequiredErrorMessage)]
        [Comment("Ad Category idenntifier")]
        [ForeignKey(nameof(CategoryId))]

        public int CategoryId { get; set; }
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Comment("Ad Category type")]
        public Category Category { get; set; } = null!;


    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Name – a string with min length 5 and max length 25 (required)
//⦁	Has Description – a string with min length 15 and max length 250 (required)
//⦁	Has Price – a decimal (required)
//⦁	Has OwnerId – a string (required)
//⦁	Has Owner – an IdentityUser (required)
//⦁	Has ImageUrl – a string (required)
//⦁	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//⦁	Has CategoryId – an integer, foreign key (required)
//⦁	Has Category – a Category (required)

