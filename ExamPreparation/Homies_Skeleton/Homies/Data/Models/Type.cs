using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    [Comment("Event types")]
    public class Type
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.TypeNameMaxLenght)]
        [Comment("Type name")]
        public string Name { get; set; }=string.Empty;
        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
