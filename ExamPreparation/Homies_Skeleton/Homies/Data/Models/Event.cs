using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Type = Homies.Data.Models.Type;

namespace Homies.Data.Models
{
    [Comment("Event data entity")]
    public class Event
    {
        [Key]
        [Comment("Event identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.EventNameMaxLenght)]
        [Comment("Event Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(DataConstants.EventDescriptionMaxLenght)]
        [Comment("Event description")]
        public string Description { get; set; }= string.Empty;
        [Required]
        [Comment("Event organiser identifier")]
        [ForeignKey(nameof(OrganiserId))]
        public string OrganiserId { get; set; } = string.Empty;
        [Required]
        public IdentityUser Organiser { get; set; } = null!;
        [Required]
        [Comment("Event creational date")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Comment("Event start date")]
        public DateTime Start { get; set;}
        [Required]
        [Comment("Event end date")]
        public DateTime End { get; set;}
        [Required]
        [Comment("Event type identifier")]
        [ForeignKey(nameof(TypeId))]
        public int TypeId { get; set; }
        [Required]
        public Type Type { get; set; }=null!;
        public List<EventParticipant> EventsParticipants { get; set; }=new List<EventParticipant>();
    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Name – a string with min length 5 and max length 20 (required)
//⦁	Has Description – a string with min length 15 and max length 150 (required)
//⦁	Has OrganiserId – an string (required)
//⦁	Has Organiser – an IdentityUser (required)
//⦁	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//⦁	Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//⦁	Has End – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//⦁	Has TypeId – an integer, foreign key (required)
//⦁	Has Type – a Type (required)
//⦁	Has EventsParticipants – a collection of type EventParticipant

