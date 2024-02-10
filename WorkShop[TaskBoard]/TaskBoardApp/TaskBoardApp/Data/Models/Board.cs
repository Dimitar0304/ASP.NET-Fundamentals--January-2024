using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace TaskBoardApp.Data.Models
{
    [Comment("Board data entity")]
    public class Board
    {
        [Key]
        [Comment("Board identifier")]
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.BoardConstants.BoardNameMaxLenght)]
        [Comment("Board name")]
        public string Name { get; set; } = null!;
        [Comment("Tasks for each board category")]
        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
//⦁	Id – a unique integer, Primary Key
//⦁	Name – a string with min length 3 and max length 30 (required)
//⦁	Tasks – a collection of Task
