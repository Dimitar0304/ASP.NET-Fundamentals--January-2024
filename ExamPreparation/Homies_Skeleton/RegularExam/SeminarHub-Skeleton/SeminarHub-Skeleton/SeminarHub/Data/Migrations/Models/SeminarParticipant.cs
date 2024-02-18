using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Migrations.Models
{
    [Comment("Seminar Participant data entity ")]
    public class SeminarParticipant
    {
        [Required]
        [Comment("Seminar identifier")]
        [ForeignKey(nameof(Seminar))]
        public int SeminarId { get; set; }
        [Required]

        public Seminar Seminar { get; set; } = null!;
        [Required]
        [Comment("Participant identifier")]
        [ForeignKey(nameof(Participant))]
        public string ParticipantId { get; set; } = null!;
        [Required]

        public IdentityUser Participant { get; set; } = null!;
    }
}