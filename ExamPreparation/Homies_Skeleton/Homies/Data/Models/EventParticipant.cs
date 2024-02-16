using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [Required]
        [Comment("Helper identifier")]
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; } = string.Empty;
        public IdentityUser Helper { get; set; } = null!;
        [Required]
        [Comment("Event identifier")]
        [ForeignKey(nameof(EventId))]
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}