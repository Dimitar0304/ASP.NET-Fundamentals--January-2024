using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class TypeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
