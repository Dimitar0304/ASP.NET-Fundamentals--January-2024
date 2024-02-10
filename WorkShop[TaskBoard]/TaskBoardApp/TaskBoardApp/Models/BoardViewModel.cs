using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models
{
    /// <summary>
    /// Board view model
    /// </summary>
    public class BoardViewModel
    {
        /// <summary>
        /// Board view model Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Board view model Name
        /// </summary>
        [Required]
        [MaxLength(DataConstants.BoardConstants.BoardNameMaxLenght)]
        [MinLength(DataConstants.BoardConstants.BoardNameMinLenght)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Board view model Task collection
        /// </summary>
        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();


    }
}
