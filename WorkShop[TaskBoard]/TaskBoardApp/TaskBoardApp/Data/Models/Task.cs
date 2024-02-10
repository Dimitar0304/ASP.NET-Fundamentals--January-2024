

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp.Data.Models
{
    [Comment("Task data entity")]
    public class Task
    {
        [Key]
        [Comment("Task identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.TaskConstants.TaskTitleMaxLenght)]
        [Comment("Task Title")]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.TaskConstants.TaskDescriptionMaxLenght)]
        [Comment("Task Description")]
        public string Description { get; set; } = null!;
        [Required]
        [Comment("Task created on")]
        public DateTime CreatedOn { get; set; }
        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }
        public Board? Board { get; set; }
        [Required]
        public string OwnerId { get; set; } = null!;
        [Required]
        public IdentityUser Owner { get; set; } = null!;

    }
//    ⦁	Id – a unique integer, Primary Key
//⦁	Title – a string with min length 5 and max length 70 (required)
//⦁	Description – a string with min length 10 and max length 1000 (required)
//⦁	CreatedOn – date and time
//⦁	BoardId – an integer
//⦁	Board – a Board object
//⦁	OwnerId – an integer(required)
//⦁	Owner – an IdentityUser object

}
