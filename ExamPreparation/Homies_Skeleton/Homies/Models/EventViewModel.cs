using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(Data.DataConstants.EventNameMaxLenght)]
        [MinLength(Data.DataConstants.EventNameMinLenght)]
        public string Name { get; set; } = string.Empty;
        [Required]

        public string Start { get; set; }=string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public string Organiser { get; set; } = string.Empty;   
    }
}
