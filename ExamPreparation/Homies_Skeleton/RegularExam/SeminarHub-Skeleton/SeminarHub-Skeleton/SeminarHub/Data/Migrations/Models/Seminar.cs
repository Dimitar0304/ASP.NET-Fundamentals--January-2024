using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Security.Policy;

namespace SeminarHub.Data.Migrations.Models
{
    [Comment("Seminar data entity")]
    public class Seminar
    {
        [Key]
        [Comment("Seminar identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.SeminarTopicMaxLenght)]
        [Comment("Seminar Topic")]
        public string Topic { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.SeminarLecturerMaxLenght)]
        [Comment("Seminar Lecturer")]
        public string Lecturer { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.SeminarDetailsMaxLenght)]
        [Comment("Seminar Details")]
        public string Details { get; set; } = null!;
        [Required]
        [Comment("Seminar Organiser identifier")]
        [ForeignKey(nameof(Organizer))]
        public string OrganizerId { get; set; } = null!;
        [Required]
        public IdentityUser Organizer { get; set; } = null!;
        [Required]
        [Comment("Seminar Date and Time")]
        public DateTime DateAndTime { get; set; }
        [Comment("Seminar duration")]
        public int Duration { get; set; }
        [Required]
        [Comment("Seminar category identifier")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Required]
        [Comment("Seminar category type")]
        public Category Category { get; set; } = null!;

        public IEnumerable<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Topic – string with min length 3 and max length 100 (required)
//⦁	Has Lecturer – string with min length 5 and max length 60 (required)
//⦁	Has Details – string with min length 10 and max length 500 (required)
//⦁	Has OrganizerId – string (required)
//⦁	Has Organizer – IdentityUser (required)
//⦁	Has DateAndTime – DateTime with format "dd/MM/yyyy HH:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//⦁	Has Duration – integer value between 30 and 180
//⦁	Has CategoryId – integer, foreign key (required)
//⦁	Has Category – Category (required)
//⦁	Has SeminarsParticipants – a collection of type SeminarParticipant

