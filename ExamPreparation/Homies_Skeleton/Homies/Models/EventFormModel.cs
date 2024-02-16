using System.ComponentModel.DataAnnotations;
using Homies.Data;
using Homies.Data.Models;

namespace Homies.Models
{
    public class EventFormModel
    {
        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        [StringLength(DataConstants.EventNameMaxLenght,
             MinimumLength = DataConstants.EventNameMinLenght,
             ErrorMessage = DataConstants.StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        [StringLength(DataConstants.EventDescriptionMaxLenght,
            MinimumLength = DataConstants.EventDescriptionMinLenght,
            ErrorMessage = DataConstants.StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        public int TypeId { get; set; }
        public string Organiser { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();

    }
}
